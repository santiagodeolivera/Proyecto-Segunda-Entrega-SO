using NUnit.Framework;
using ProyectoSO.Lib;
using System;

namespace ProyectoSO.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Scheduler sch = new(cantNucleos: 1, quantum: 100);

            (string, byte, uint)[] procesos = {
                ("A", 1, 1000),
                ("B", 2, 1000)
            };

            Assert.IsEmpty(sch.InsertarProcesos(procesos));

            bool finished;
            do
            {
                finished = sch.Actualizar(25);
                Console.WriteLine(sch.TablaProcesos());
            } while (!finished);
        }
    }
}
