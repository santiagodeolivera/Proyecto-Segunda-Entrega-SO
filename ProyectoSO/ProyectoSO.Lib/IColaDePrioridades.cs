using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSO.Lib
{
    public interface IColaDePrioridades : IEnumerable<Proceso>
    {
        void Push(Proceso proceso);

        bool Remove(Proceso proceso);

        Proceso Pop();
    }
}
