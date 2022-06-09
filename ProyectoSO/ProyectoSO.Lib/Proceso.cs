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
        public uint TiempoRestante { get; private set; }

        public Proceso(string nombre, byte prioridad, uint tiempoRestante)
        {
            this.Nombre = nombre;
            this.Prioridad = prioridad;
            this.Bloqueado = false;
            this.TiempoRestante = tiempoRestante;
        }

        public void Modificar(ProcesoDatos datos)
        {
            this.Prioridad = datos.Prioridad;
            this.Bloqueado = datos.Bloqueado;
        }

        public ProcesoDatos Datos => new ProcesoDatos(this.Prioridad, this.Bloqueado);

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