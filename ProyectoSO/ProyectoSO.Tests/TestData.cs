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
    public record TestData(
        string Archivo,
        (string, byte, uint)[] Procesos,
        byte CantNucleos,
        uint Quantum,
        Action<Scheduler> Test
    )
    {
        public TestData(
                string archivo,
                byte cantNucleos,
                uint quantum,
                Action<Scheduler> test,
                params (string, byte, uint)[] procesos
            ) : this(archivo, procesos, cantNucleos, quantum, test)
        { }
    }
}
