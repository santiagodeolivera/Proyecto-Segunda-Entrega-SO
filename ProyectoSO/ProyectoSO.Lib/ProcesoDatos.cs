﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSO.Lib
{
    public struct ProcesoDatos
    {
        public readonly byte Prioridad;
        public readonly bool Bloqueado;
        public readonly bool Kernel;

        public ProcesoDatos(byte prioridad, bool bloqueado, bool kernel)
        {
            Prioridad = prioridad;
            Bloqueado = bloqueado;
            Kernel = kernel;
        }
    }
}
