using NUnit.Framework;
using ProyectoSO.Lib;
using System;
using System.Collections.Generic;
using System.IO;

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

        private void Test1Inner(Scheduler sch)
        {
            for (int i = 1; i <= 1000; i++)
            {
                if (sch.Actualizar(25)) return;
                Print();
                Print("Tabla tras {0} microsegundos:", i * 25);
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
            throw new Exception("Posible bucle infinito");
        }

        [Test]
        public void Test1()
        {
            // Lista de tests para hacer
            TestData[] tests =
            {
                new TestData("test1.txt", 1, 100, Test1Inner,
                    new ProcesoPlantilla("A", 1, false, 1000),
                    new ProcesoPlantilla("B", 2, false, 1000)
                ),
                new TestData("test2.txt", 2, 100, Test1Inner,
                    new ProcesoPlantilla("A", 1, false, 1000),
                    new ProcesoPlantilla("B", 2, false, 1000),
                    new ProcesoPlantilla("C", 3, false, 4000)
                ),
                new TestData("test3.txt", 2, 100, Test1Inner,
                    new ProcesoPlantilla("A", 1, false, 1000),
                    new ProcesoPlantilla("B", 2, false, 1000),
                    new ProcesoPlantilla("C", 3, false, 2000)
                )
            };

            foreach (TestData test in tests)
            {
                StreamWriter writer = File.CreateText(test.Archivo);
                printer = writer.WriteLine;

                Scheduler sch = new Scheduler(test.CantNucleos, test.Quantum);
                Assert.IsEmpty(sch.InsertarProcesos(test.Procesos));

                try
                {
                    test.Test.Invoke(sch);
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
