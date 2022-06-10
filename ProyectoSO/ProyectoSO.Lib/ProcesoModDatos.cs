using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSO.Lib
{
    /// <summary>
    /// Contiene información para modificar un proceso.
    /// </summary>
    public struct ProcesoModDatos
    {
        public byte Prioridad;
        public bool Bloqueado;

        public ProcesoModDatos(byte prioridad, bool bloqueado)
        {
            Prioridad = prioridad;
            Bloqueado = bloqueado;
            
        }
    }
}
