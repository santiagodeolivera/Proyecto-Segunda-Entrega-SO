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
                        estado = "en ejecución";
                        break;
                    case EstadoProceso.Bloqueado:
                        estado = "bloqueado";
                        break;
                    default:
                        throw new Exception();
                }

                Print("\t{0,10} -> prioridad {1:D2}, {2,-12}, {3,-12}", nombre, prioridad, bloqueado, estado);
            }
        }

        private void Test1Inner(Scheduler sch, ICollection<(string, IEnumerator<LockAction>)> lockers)
        {
            for (int i = 1; i <= 1000; i++)
            {
                if (sch.Actualizar(25)) return;
                Print();
                Print("Tabla tras {0} microsegundos:", i * 25);
                ImprimirTabla(sch);
                bool modGuarda = false;
                foreach ((string, IEnumerator<LockAction>) tupla in lockers)
                {
                    string nombre = tupla.Item1;
                    IEnumerator<LockAction> locker = tupla.Item2;
                    if (sch.BuscarProceso(nombre) is ProcesoDatos datos && locker.MoveNext())
                    {
                        ProcesoModDatos modDatos = new ProcesoModDatos(datos);
                        switch (locker.Current)
                        {
                            case LockAction.Lock:
                                modDatos.Bloqueado = true;
                                modGuarda = true;
                                break;
                            case LockAction.Unlock:
                                modDatos.Bloqueado = false;
                                modGuarda = true;
                                break;
                        }
                        sch.ModificarProceso(nombre, modDatos);
                    }
                }
                if (modGuarda)
                {
                    Print();
                    Print("Tabla tras bloqueo/desbloqueo:");
                    ImprimirTabla(sch);
                }
            }
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
                )
            };

            foreach (TestData test in tests)
            {
                StreamWriter writer = File.CreateText(test.Archivo);
                printer = writer.WriteLine;

                Scheduler sch = new Scheduler(test.CantNucleos, test.Quantum);
                Assert.IsEmpty(sch.InsertarProcesos(test.Procesos.Select(v => v.Item1)));

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
