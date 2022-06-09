using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSO.Lib
{
    public class Scheduler : ISimuladorTiempo<bool>
    {
        /*
         * Los métodos deben ejecutarse bajo mutua exclusión.
         */

        private readonly object _lock = new();

        /// <summary>
        /// Una estructura donde se almacenan todos los procesos del scheduler.
        /// </summary>
        private readonly IDictionary<string, Proceso> procesos = new Dictionary<string, Proceso>();

        /// <summary>
        /// La cantidad de núcleos del scheduler.
        /// </summary>
        private readonly byte cantNucleos;

        /// <summary>
        /// La cantidad de microsegundos del quantum.
        /// </summary>
        private readonly uint quantum;

        /// <summary>
        /// La cola de procesos listos.
        /// 
        /// Es una LinkedList en vez de un Queue porque se debe poder sacar los procesos en medio cuando se bloquean,
        /// lo cual no está permitido por un Queue.
        /// </summary>
        private readonly LinkedList<Proceso> procesosListos = new LinkedList<Proceso>();

        /// <summary>
        /// Los procesos en ejecución, siendo su llave la id del CPU donde se ejecuta,
        /// que va de 0 (inclusive) a cantNucleos (exclusive).
        /// </summary>
        private readonly IDictionary<byte, (Proceso, uint)> procesosEnEjecucion = new Dictionary<byte, (Proceso, uint)>();

        /// <summary>
        /// Los procesos bloqueados.
        /// </summary>
        private readonly IDictionary<string, Proceso> procesosBloqueados = new Dictionary<string, Proceso>();

        public Scheduler(byte cantNucleos, uint quantum)
        {
            this.cantNucleos = cantNucleos;
            this.quantum = quantum;
        }

        public ISet<string> InsertarProcesos(ICollection<(string, byte, uint)> procesos)
        {
            lock (this._lock)
            {
                ISet<string> res = new HashSet<string>();
                foreach ((string nombre, byte prioridad, uint tiempoEjec) in procesos)
                {
                    if (!this.InsertarProceso(nombre, prioridad, tiempoEjec))
                    {
                        res.Add(nombre);
                    }
                }

                return res;
            }
        }

        public bool InsertarProceso(string nombre, byte prioridad, uint tiempoEjec)
        {
            if (this.procesos.ContainsKey(nombre))
            {
                return false;
            }

            Proceso proceso = new(nombre, prioridad, tiempoEjec);
            this.procesos.Add(nombre, proceso);
            this.procesosListos.AddFirst(proceso);
            return true;
        }

        public bool ModificarProceso(string nombre, ProcesoDatos datos)
        {
            lock (this._lock)
            {
                if (this.procesos.TryGetValue(nombre, out var proceso))
                {
                    // Si el proceso pasa de bloqueado a desbloqueado,
                    // se saca de los procesos bloqueados y se lo inserta en los procesos listos.
                    if (proceso.Bloqueado && !datos.Bloqueado)
                    {
                        this.procesosBloqueados.Remove(nombre);
                        this.procesosListos.AddFirst(proceso);
                    }

                    // Si el proceso pasa de desbloqueado a bloqueado,
                    // se saca de las otras dos estructuras y se pasa a procesos bloqueados.
                    if (!proceso.Bloqueado && datos.Bloqueado)
                    {
                        if (!this.procesosListos.Remove(proceso))
                        {
                            byte cpuId = this.procesosEnEjecucion.Where(pair => pair.Value.Item1.Nombre.Equals(nombre)).First().Key;
                            this.procesosEnEjecucion.Remove(cpuId);
                        }

                        this.procesosBloqueados.Add(nombre, proceso);
                    }


                    proceso.Modificar(datos);
                    return true;
                }

                return false;
            }
        }

        public IDictionary<string, (ProcesoDatos, EstadoProceso)> TablaProcesos()
        {
            lock (this._lock)
            {
                IDictionary<string, (ProcesoDatos, EstadoProceso)> res = new Dictionary<string, (ProcesoDatos, EstadoProceso)>();
                foreach (KeyValuePair<string, Proceso> item in this.procesos)
                {
                    string nombre = item.Key;
                    Proceso proceso = item.Value;

                    EstadoProceso estadoProceso;
                    if (proceso.Bloqueado)
                    {
                        estadoProceso = EstadoProceso.Bloqueado;
                    }
                    else if (this.procesosEnEjecucion.Any(pair => pair.Value.Item1.Nombre.Equals(nombre)))
                    {
                        estadoProceso = EstadoProceso.EnEjecucion;
                    }
                    else
                    {
                        estadoProceso = EstadoProceso.Listo;
                    }

                    res.Add(nombre, (proceso.Datos, estadoProceso));
                }

                return res;
            }
        }

        public ProcesoDatos? BuscarProceso(string nombre)
        {
            lock (this._lock)
            {
                if (this.procesos.TryGetValue(nombre, out var proceso))
                {
                    return proceso.Datos;
                }
                return null;
            }
        }

        public IDictionary<byte, (string, ProcesoDatos)> ProcesosEnCPU()
        {
            lock (this._lock)
            {
                return this.procesosEnEjecucion.Select(item =>
                {
                    byte cpuId = item.Key;
                    Proceso proceso = item.Value.Item1;

                    return new KeyValuePair<byte, (string, ProcesoDatos)>(cpuId, (proceso.Nombre, proceso.Datos));
                }).ToDictionary(pair => pair.Key, pair => pair.Value);
            }
        }

        public IList<(string, ProcesoDatos)> ProcesosListos()
        {
            lock (this._lock)
            {
                return this.procesosListos.Select(proceso => (proceso.Nombre, proceso.Datos)).ToList();
            }
        }

        public ICollection<(string, ProcesoDatos)> ProcesosBloqueados()
        {
            lock (this._lock)
            {
                return this.procesosBloqueados.Values.Select(proceso => (proceso.Nombre, proceso.Datos)).ToArray();
            }
        }

        public bool Actualizar(uint tiempo)
        {
            lock (this._lock)
            {
                /*
                 * Rellenar CPUs sin usar con procesos en la lista de procesos listos.
                 * Revisar todos los procesos en ejecución, a ver cuánto se pueden adelantar todos.
                 * Remover los que hayan terminado su quantum, y colocarlos en la cola de procesos listos.
                 * Devolver si se ejecutaron todos los procesos.
                 */

                while (tiempo > 0)
                {
                    // Chequear cuánto tiempo se mantienen todos los procesos en la CPU sin hacer ningún cambio.
                    uint? min = null;
                    for (byte i = 0; i < cantNucleos; i++)
                    {
                        // Si hay CPUs sin procesos y procesos en la cola, se los asignan
                        if (!this.procesosEnEjecucion.TryGetValue(i, out var procesoEjec) && this.procesosListos.Count > 0)
                        {
                            Proceso proceso = this.procesosListos.Last();
                            this.procesosListos.RemoveLast();

                            this.procesosEnEjecucion.Add(i, (proceso, this.quantum * proceso.Prioridad));
                            procesoEjec = (proceso, this.quantum);
                        }

                        // Algoritmo usual para conseguir el mínimo tiempo de los tiempos de todos los procesos.
                        if (min == null || min > procesoEjec.Item2)
                        {
                            min = procesoEjec.Item2;
                        }
                    }

                    // Si no hay más procesos, se termina la ejecución.
                    if (min is not uint min2)
                    {
                        return true;
                    }

                    // Restar a la cantidad de tiempo de cada proceso el mínimo encontrado,
                    // y a los que se les acabe el tiempo, son colocados en la cola de procesos listos.
                    for (byte i = 0; i < cantNucleos; i++)
                    {
                        if (this.procesosEnEjecucion.TryGetValue(i, out var procesoEjec))
                        {
                            (Proceso proceso, uint tiempoRestante) = procesoEjec;
                            uint nuevoTiempo = tiempoRestante - min2;

                            this.procesosEnEjecucion.Remove(i);
                            if (proceso.Actualizar(min2))
                            {
                                this.procesos.Remove(proceso.Nombre);
                            } else if (nuevoTiempo == 0)
                            {
                                this.procesosListos.AddFirst(procesoEjec.Item1);
                            } else
                            {
                                this.procesosEnEjecucion.Add(i, (procesoEjec.Item1, nuevoTiempo));
                            }
                        }
                    }

                    // Restar dicha cantidad del tiempo al tiempo solicitado.
                    tiempo -= min2;
                }

                return false;
            }
        }
    }
}
