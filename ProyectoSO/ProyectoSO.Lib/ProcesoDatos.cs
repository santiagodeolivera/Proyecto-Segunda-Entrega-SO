using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSO.Lib
{
    public struct ProcesoDatos
    {
        public byte Prioridad;
        public bool Bloqueado;

        public ProcesoDatos(byte prioridad, bool bloqueado)
        {
            Prioridad = prioridad;
            Bloqueado = bloqueado;
        }
    }
}
