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
    public class ColaDePrioridades : IColaDePrioridades
    {
        private readonly LinkedList<Proceso> lista = new LinkedList<Proceso>();

        public void Push(Proceso proceso)
        {
            if (this.lista.Count == 0)
            {
                this.lista.AddFirst(proceso);
                return;
            }

            LinkedListNode<Proceso> after = this.lista.Last;
            if (after.Value.Prioridad < proceso.Prioridad)
            {
                this.lista.AddLast(proceso);
                return;
            }

            while (after.Previous != null &&
                after.Previous.Value.Prioridad > proceso.Prioridad)
            {
                after = after.Previous;
            }
            this.lista.AddBefore(after, proceso);
        }

        public Proceso Pop()
        {
            if (this.lista.Count == 0)
            {
                return null;
            }

            Proceso res = this.lista.Last();
            this.lista.RemoveLast();
            return res;
        }

        public bool Remove(Proceso proceso)
            => this.lista.Remove(proceso);

        IEnumerator<Proceso> IEnumerable<Proceso>.GetEnumerator()
            => (this.lista as IEnumerable<Proceso>).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => (this.lista as IEnumerable).GetEnumerator();
    }
}
