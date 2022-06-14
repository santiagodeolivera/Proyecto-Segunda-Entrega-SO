using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSO.Lib
{
    public interface ISimuladorTiempo<T>
    {
        /// <summary>
        /// Actualiza la estructura como si hubiera pasado una cierta cantidad de tiempo.
        /// </summary>
        /// <param name="tiempo">El tiempo que se simula, en microsegundos.</param>
        /// <returns>Un valor relevante respecto a la actualización.</returns>
        T Actualizar(uint tiempo);
    }
}
