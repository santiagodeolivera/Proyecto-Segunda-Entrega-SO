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

        private readonly object _lock = new object();

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
        /// El quantum es la cantidad de tiempo en la cual un proceso se encuentra en CPU antes de salir por timeout.
        /// </summary>
        private readonly uint quantum;

        /// <summary>
        /// La cola de procesos listos.
        /// </summary>
        private readonly IColaDePrioridades procesosListos = new ColaDePrioridades();

        /// <summary>
        /// Los procesos en ejecución, siendo su llave la id del CPU donde se ejecuta,
        /// que va de 0 (inclusive) a cantNucleos (exclusive).
        /// El valor representa el proceso en dicha CPU, junto con la cantidad de tiempo que le queda antes
        /// de volver a la cola de procesos listos.
        /// </summary>
        private readonly IDictionary<byte, (Proceso, uint)> procesosEnEjecucion = new Dictionary<byte, (Proceso, uint)>();

        /// <summary>
        /// Los procesos bloqueados.
        /// </summary>
        private readonly IDictionary<string, Proceso> procesosBloqueados = new Dictionary<string, Proceso>();

        public Scheduler(byte cantNucleos, uint quantum)
        {
            if (cantNucleos == 0 || quantum == 0)
            {
                throw new ArgumentException();
            }

            this.cantNucleos = cantNucleos;
            this.quantum = quantum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="procesos"></param>
        /// <returns>
        /// El conjunto de los nombres de los procesos que no pudieron insertarse en el scheduler
        /// porque ya estaban en el scheduler.
        /// </returns>
        public ISet<string> InsertarProcesos(IEnumerable<ProcesoPlantilla> procesos)
        {
            lock (this._lock)
            {
                ISet<string> res = new HashSet<string>();
                foreach (ProcesoPlantilla plantilla in procesos)
                {
                    if (!this.InsertarProceso(plantilla))
                    {
                        res.Add(plantilla.Nombre);
                    }
                }

                return res;
            }
        }

        public bool InsertarProceso(ProcesoPlantilla plantilla)
        {
            lock (this._lock)
            {
                if (this.procesos.ContainsKey(plantilla.Nombre))
                {
                    return false;
                }

                Proceso proceso = new Proceso(plantilla);
                this.procesos.Add(plantilla.Nombre, proceso);
                this.procesosListos.Push(proceso);
                return true;
            }
        }

        public bool ModificarProceso(string nombre, ProcesoModDatos datos)
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
                        this.procesosListos.Push(proceso);
                    }

                    // Si el proceso pasa de desbloqueado a bloqueado,
                    // se saca de las otras dos estructuras y se pasa a procesos bloqueados.
                    if (!proceso.Bloqueado && datos.Bloqueado)
                    {
                        if (!this.procesosListos.Remove(proceso))
                        {
                            /*
                             this.procesosEnEjecución es un diccionario, el cual cuenta como enumerable de pares clave-valor.
                             La función Filter crea otro enumerable con los datos del anterior, los cuales cumplen una cierta condición.
                                En este caso se usa para encontrar el par clave-valor cuyo valor tenga un proceso con el nombre especificado.
                             La función First obtiene el primer elemento del enumerable.
                             La propiedad Key obtiene la clave del par clave-valor.
                             */
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// Un diccionario con información de todos los procesos del scheduler,
        /// para hacer la tabla en la interfaz gráfica.
        /// </returns>
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
                    else if (this.procesosListos.Any(p => p.Nombre.Equals(nombre)))
                    {
                        estadoProceso = EstadoProceso.Listo;
                    }
                    else
                    {
                        throw new Exception("Situación inesperada");
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
                /*
                 El método Select devuelve un enumerable que resulta en mapear los elementos del anterior en la función determinada.
                 Ejemplo:
                     n = [2, 3]
                     n2 = n.Select(v => 2 * v)
                     assert n2 == [4, 6]

                 El método ToDictionary devuelve un diccionario a partir de un enumerable, en los cuales se define la clave y el valor
                    mediante dos funciones.
                 Ejemplo:
                     arr = [4, 5, 6]
                     dicc = arr.ToDictionary(v => v + 1, v => v - 2)
                     assert dicc == {5: 3, 6: 4, 7: 5}
                 */
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
                /*
                 El método ToList transforma un enumerable en una lista de elementos.
                 */
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
                    uint min = tiempo;
                    for (byte i = 0; i < cantNucleos; i++)
                    {
                        // Si hay CPUs sin procesos y procesos en la cola, se los asignan
                        if (!this.procesosEnEjecucion.TryGetValue(i, out var procesoEjec))
                        {
                            if (this.procesosListos.Pop() is Proceso proceso)
                            {
                                this.procesosEnEjecucion.Add(i, (proceso, this.quantum * proceso.Prioridad));
                                procesoEjec = (proceso, this.quantum * proceso.Prioridad);
                            } else
                            {
                                continue;
                            }
                        }

                        // Algoritmo usual para conseguir el mínimo tiempo de los tiempos de todos los procesos.
                        if (min > procesoEjec.Item2)
                        {
                            min = procesoEjec.Item2;
                        }
                    }

                    // Restar a la cantidad de tiempo de cada proceso el mínimo encontrado,
                    // y a los que se les acabe el tiempo, son colocados en la cola de procesos listos.
                    for (byte i = 0; i < cantNucleos; i++)
                    {
                        if (!this.procesosEnEjecucion.TryGetValue(i, out var procesoEjec))
                        {
                            continue;
                        }
                        (Proceso proceso, uint tiempoRestante) = procesoEjec;
                        uint nuevoTiempo = tiempoRestante - min;

                        this.procesosEnEjecucion.Remove(i);
                        if (proceso.Actualizar(min))
                        {
                            this.procesos.Remove(proceso.Nombre);
                        } else if (nuevoTiempo == 0)
                        {
                            this.procesosListos.Push(procesoEjec.Item1);
                        } else
                        {
                            this.procesosEnEjecucion.Add(i, (procesoEjec.Item1, nuevoTiempo));
                        }
                    }

                    // Restar dicha cantidad del tiempo al tiempo solicitado.
                    tiempo -= min;
                }

                return this.procesos.Count == 0;
            }
        }
    }
}
