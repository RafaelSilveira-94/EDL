using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filas
{
    internal interface IFila
    {
        public abstract void Enfileirar(object o);
        public abstract Object Desinfileirar();
        public Object First { get; }
        public abstract int Size { get; }
        public abstract bool IsEmpty();
    }
}
