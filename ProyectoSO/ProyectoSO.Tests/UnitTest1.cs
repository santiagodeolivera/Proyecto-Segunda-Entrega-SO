using NUnit.Framework;
using ProyectoSO.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using ProyectoSO.Tests.TimedLock;

namespace ProyectoSO.Tests
{
    public partial class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private Action<string> printer = null;

        private void Print(string text, params object[] ob)
        {
            if (printer == null)
            {
                printer = Console.WriteLine;
            }

            printer(string.Format(text, ob));
        }

        private void Print()
        {
            Print(string.Empty);
        }

        private void ImprimirTabla(Scheduler sch)
        {
            IDictionary<string, (ProcesoDatos, EstadoProceso)> tabla = sch.TablaProcesos();
            foreach (KeyValuePair<string, (ProcesoDatos, EstadoProceso)> keyValuePair in tabla)
            {
                string nombre = keyValuePair.Key;
                byte prioridad = keyValuePair.Value.Item1.Prioridad;
                string bloqueado = keyValuePair.Value.Item1.Bloqueado
                    ? "bloqueado"
                    : "no bloqueado";
                string estado;
                switch (keyValuePair.Value.Item2)
                {
                    case EstadoProceso.Listo:
                        estado = "listo";
                        break;
                    case EstadoProceso.EnEjecucion:
                        estado = "en ejecuci�n";
                        break;
                    case EstadoProceso.Bloqueado:
                        estado = "bloqueado";
                        break;
                    default:
                        throw new Exception();
                }

                Print("\t{0,20} -> prioridad {1:D2}, {2,-12}, {3,-12}", nombre, prioridad, bloqueado, estado);
            }
        }

        /// <summary>
        /// Dependiendo del valor de lockAction, el valor Bloqueado de modDatos cambia o no.
        /// </summary>
        /// <param name="modDatos">El ProcesoModDatos a modificar.</param>
        /// <param name="lockAction">El LockAction que determina c�mo se modifica.</param>
        /// <returns>true si hubo un bloqueo/desbloqueo en el proceso.</returns>
        public static bool ModificarProcesoDatos(ref ProcesoModDatos modDatos, LockAction lockAction)
        {
            // Si se pide bloquear el proceso, se cambia Bloqueado a true,
            // no hace nada si el proceso ya est� bloqueado.
            if (lockAction == LockAction.Lock)
            {
                modDatos.Bloqueado = true;
                return true;
            }
            // Si se pide desbloquear el proceso, se cambia Bloqueado a false,
            // no hace nada si el proceso ya est� desbloqueado.
            else if (lockAction == LockAction.Unlock)
            {
                modDatos.Bloqueado = false;
                return true;
            }
            else
            // Si no se pide nada, modDatos se mantiene intacto.
            {
                return false;
            }
        }

        private void Test1Inner(Scheduler sch, ICollection<(string, IEnumerator<LockAction>)> lockers)
        {
            // Se impone un l�mite de 1000 iteraciones para evitar un bucle infinito
            for (int i = 1; i <= 1000; i++)
            {
                // Se actualiza el scheduler como si hubieran pasado 25 microsegundos.
                // Si el m�todo devuelve true (o sea, si terminaron de ejecutarse todos los procesos),
                //     se sale del bucle sin pasar por el c�digo de abajo.
                if (sch.Actualizar(25)) return;

                // Se imprime la informaci�n de la tabla en el archivo.
                Print();
                Print("Tabla tras {0} microsegundos:", i * 25);
                ImprimirTabla(sch);

                // Se bloquean y desbloquean los procesos
                // La variable modGuarda determina si se bloque�/desbloque� al menos un proceso,
                //     y sirve para ver si hay que reimprimir la tabla.
                bool modGuarda = false;
                foreach ((string, IEnumerator<LockAction>) tupla in lockers)
                {
                    string nombre = tupla.Item1;
                    IEnumerator<LockAction> locker = tupla.Item2;
                    if (sch.BuscarProceso(nombre) is ProcesoDatos datos && locker.MoveNext())
                    {
                        ProcesoModDatos modDatos = new ProcesoModDatos(datos);
                        modGuarda |= ModificarProcesoDatos(ref modDatos, locker.Current);
                        sch.ModificarProceso(nombre, modDatos);
                    }
                }

                // Si se bloque�/desbloque� al menos un proceso,
                //     se imprime la informaci�n de la tabla en el archivo.
                if (modGuarda)
                {
                    Print();
                    Print("Tabla tras bloqueo/desbloqueo:");
                    ImprimirTabla(sch);
                }
            }

            // Si se sale del bucle sin pasar por la sentencia "return", se tira un error.
            throw new Exception("Posible bucle infinito");
        }

        [Test]
        public void Test1()
        {
            // Lista de tests para hacer
            TestData[] tests =
            {
                new TestData("Test1.txt", 1, 100, Test1Inner,
                    (new ProcesoPlantilla("A", 1, false, 1000), null),
                    (new ProcesoPlantilla("B", 2, false, 1000), null)
                ),
                new TestData("Test2.txt", 2, 100, Test1Inner,
                    (new ProcesoPlantilla("A", 1, false, 1000), null),
                    (new ProcesoPlantilla("B", 2, false, 1000), null),
                    (new ProcesoPlantilla("C", 3, false, 4000), null)
                ),
                new TestData("Test3.txt", 2, 100, Test1Inner,
                    (new ProcesoPlantilla("A", 1, false, 1000), null),
                    (new ProcesoPlantilla("B", 2, false, 1000), null),
                    (new ProcesoPlantilla("C", 3, false, 2000), null)
                ),
                new TestData("Test4.txt", 2, 100, Test1Inner,
                    (new ProcesoPlantilla("A", 1, false, 1000), null),
                    (new ProcesoPlantilla("B", 2, false, 1000), null),
                    (new ProcesoPlantilla("C", 3, false, 2000), new TimedLockEnumerator(6, 2))
                ),
                new TestData("Test5.txt", 1, 100, Test1Inner,
                    (new ProcesoPlantilla("Proceso 1", 1, false, 500), new TimedLockEnumerator(2, 1)),
                    (new ProcesoPlantilla("Proceso 2", 2, false, 1000), new TimedLockEnumerator(2, 4)),
                    (new ProcesoPlantilla("Proceso 3", 4, false, 2000), new TimedLockEnumerator(6, 2)))
            };

            // Determinar en qu� directorio se colocar�n las salidas de los tests
            string rutaDir;
            {
                DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
                while (!dir.Name.Equals("ProyectoSO"))
                {
                    dir = dir.Parent;
                }
                rutaDir = Path.Combine(dir.FullName, "ProyectoSO.Tests", "Test_outputs");
                Directory.CreateDirectory(rutaDir);
            }

            // Ejecutar cada test
            foreach (TestData test in tests)
            {
                // Preparar el archivo
                StreamWriter writer = File.CreateText(Path.Combine(rutaDir, test.Archivo));
                printer = writer.WriteLine;

                // Preparar el scheduler
                Scheduler sch = new Scheduler(test.CantNucleos, test.Quantum);
                Assert.IsEmpty(sch.InsertarProcesos(test.Procesos.Select(v => v.Item1)));

                // Preparar los objetos que bloquean/desbloquean los procesos
                ICollection<(string, IEnumerator<LockAction>)> lockers =
                    test.Procesos.Where(v => v.Item2 != null).Select(p => (p.Item1.Nombre, p.Item2)).ToList();

                try
                {
                    test.Test.Invoke(sch, lockers);
                }
                finally
                {
                    printer = null;
                    writer.Close();
                }
            }

        }
    }
}
