using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSO.Lib
{
    /// <summary>
    /// Contiene toda la información para crear un proceso nuevo.
    /// Algo así como una plantilla para crear procesos.
    /// </summary>
    public struct ProcesoPlantilla
    {
        public readonly string Nombre;
        public readonly byte Prioridad;
        public readonly bool Kernel;
        public readonly uint TiempoRestante;

        public static readonly uint LimiteCaracteresNombre = 10;

        public ProcesoPlantilla(string nombre, byte prioridad, bool kernel, uint tiempoRestante)
        {
            // Guarda contra parámetros inválidos.
            if (string.IsNullOrWhiteSpace(nombre) || prioridad == 0 || prioridad > 99 || nombre.Length == 0 || nombre.Length > LimiteCaracteresNombre)
            {
                throw new ArgumentException();
            }

            Nombre = nombre;
            Prioridad = prioridad;
            Kernel = kernel;
            TiempoRestante = tiempoRestante;
        }
    }
}
