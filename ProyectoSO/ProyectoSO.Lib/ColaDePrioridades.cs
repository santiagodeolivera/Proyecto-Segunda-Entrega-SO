using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSO.Lib
{
    /// <summary>
    /// Esta clase representa una cola de procesos, a los cuales se les añade
    /// tomando en cuenta su prioridad.
    /// Utiliza una LinkedList en vez de un Queue porque se debe poder sacar los
    /// procesos en medio cuando se bloquean, e insertarlos de acuerdo a su prioridad.
    /// </summary>
    public class ColaDePrioridades : IEnumerable<Proceso>
    {
        private readonly LinkedList<Proceso> lista = new LinkedList<Proceso>();
        public uint Tamaño { get; private set; } = 0;

        private static uint posicionarProceso(byte prioridad, uint tamaño)
            => (uint)Math.Round((double)(prioridad - 1) * tamaño / 98);

        public void Insertar(Proceso proceso)
        {
            uint pos = posicionarProceso(proceso.Prioridad, this.Tamaño);

            if (pos == 0)
            {
                this.lista.AddFirst(proceso);
            } else
            {
                LinkedListNode<Proceso> aux = this.lista.First;
                pos--;
                while (pos > 0 && aux != null)
                {
                    aux = aux.Next;
                    pos--;
                }

                if (aux == null)
                {
                    this.lista.AddLast(proceso);
                } else
                {
                    this.lista.AddAfter(aux, proceso);
                }
            }

            this.Tamaño++;
        }

        public bool Remover(Proceso proceso)
        {
            if (this.lista.Remove(proceso))
            {
                this.Tamaño--;
                return true;
            }

            return false;
        }

        public Proceso Pop()
        {
            Proceso res = this.lista.Last();
            this.lista.RemoveLast();
            this.Tamaño--;
            return res;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)lista).GetEnumerator();
        }
        public IEnumerator<Proceso> GetEnumerator()
        {
            return ((IEnumerable<Proceso>)lista).GetEnumerator();
        }

    }
}
