using ProyectoSO.Lib;
using System;
using System.Collections.Generic;
using ProyectoSO.Tests.TimedLock;

namespace ProyectoSO.Tests
{
    /// <summary>
    /// Contiene toda la información respecto a un test relacionado con el Scheduler.
    /// </summary>
    public struct TestData
    {
        /// El nombre del archivo al cual se imprimen los resultados.
        public string Archivo;

        /// <summary>
        /// Plantillas para los procesos que tendrá el scheduler.
        /// El segundo elemento de la tupla representa un objeto
        /// que determina cuándo bloquear el proceso y cuándo desbloquearlo.
        /// </summary>
        public IEnumerable<(ProcesoPlantilla, IEnumerator<LockAction>)> Procesos;

        /// <summary>
        /// La cantidad de núcleos del scheduler.
        /// </summary>
        public byte CantNucleos;

        /// <summary>
        /// El quantum del scheduler, en microsegundos.
        /// </summary>
        public uint Quantum;

        /// <summary>
        /// Una función que recibe el scheduler y lo utiliza.
        /// </summary>
        public Action<Scheduler, ICollection<(string, IEnumerator<LockAction>)>> Test;

        public TestData(
            string archivo,
            byte cantNucleos,
            uint quantum,
            Action<Scheduler, ICollection<(string, IEnumerator<LockAction>)>> test,
            params (ProcesoPlantilla, IEnumerator<LockAction>)[] procesos
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
