using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tad_Vetor
{
    public interface IVetorLigado
    {
        int Size();
        bool IsEmpty();
        object Last { get; }
        object First { get; }
        object Before(object n);
        object After(object n);
        object ReplaceElement(object n,object o);
        void SwapElements(object n,object o);
        void InsertBefore(object n,object o);
        void InsertAfter(object n,object o);
        void InsertFirst(object n);
        void InsertLast(object n);
        object Remove(object n);

    }
}
