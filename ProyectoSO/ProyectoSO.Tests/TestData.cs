using ProyectoSO.Lib;
using System;

namespace ProyectoSO.Tests
{
    /// <summary>
    /// Contiene toda la información respecto a un test relacionado con el Scheduler.
    /// </summary>
    /// <param name="Archivo">El nombre del archivo al cual se imprimen los resultados.</param>
    /// <param name="Procesos">La plantilla de procesos iniciales del scheduler.</param>
    /// <param name="CantNucleos">La cantidad de núcleos del scheduler.</param>
    /// <param name="Quantum">El quantum del scheduler, en microsegundos.</param>
    /// <param name="Test">Una función que recibe el scheduler y lo utiliza.</param>
    public struct TestData
    {
        public string Archivo;
        public (string, byte, uint)[] Procesos;
        public byte CantNucleos;
        public uint Quantum;
        public Action<Scheduler> Test;

        public TestData(
            string archivo,
            byte cantNucleos,
            uint quantum,
            Action<Scheduler> test,
            params (string, byte, uint)[] procesos
        )
        {
            this.Archivo = archivo;
            this.CantNucleos = cantNucleos;
            this.Quantum = quantum;
            this.Test = test;
            this.Procesos = procesos;
        }
    }
}
