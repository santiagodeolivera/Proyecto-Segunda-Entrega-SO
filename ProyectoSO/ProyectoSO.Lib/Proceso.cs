using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSO.Lib
{
    public class Proceso : ISimuladorTiempo<bool>
    {
        public readonly string Nombre;

        public byte Prioridad { get; private set; }

        public bool Bloqueado { get; private set; }

        /// <summary>
        /// Determina si este proceso fue creado por el kernel o por el usuario.
        /// </summary>
        public readonly bool Kernel;

        public uint TiempoRestante { get; private set; }

        public Proceso(ProcesoPlantilla plantilla)
        {
            this.Nombre = plantilla.Nombre;
            this.Prioridad = plantilla.Prioridad;
            this.Bloqueado = false;
            this.Kernel = plantilla.Kernel;
            this.TiempoRestante = plantilla.TiempoRestante;
        }

        public void Modificar(ProcesoModDatos datos)
        {
            this.Prioridad = datos.Prioridad;
            this.Bloqueado = datos.Bloqueado;
        }

        public ProcesoDatos Datos => new ProcesoDatos(this.Prioridad, this.Bloqueado, this.Kernel);

        public bool Actualizar(uint tiempo)
        {
            if (this.TiempoRestante <= tiempo)
            {
                this.TiempoRestante = 0;
                return true;
            } else
            {
                this.TiempoRestante -= tiempo;
                return false;
            }
        }
    }
}