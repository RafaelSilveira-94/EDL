using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequencia
{
    public interface ISequencia
    {
        public int Size();
        public bool IsEmpty();
        public object First();
        public object Last();
        public object ElemAtRank(int r);
        public object Before(object o);
        public object After(object o);
        public object ReplaceAtRank(int r, object o);
        public void InsertAtRank(int r, object o);
        public object RemoveAtRank(int r);
        public object ReplaceElement(object n, object o);
        public object SwapElement(object n, object o);
        public void InsertBefore(object n, object o);
        public void InsertAfter(object n, object o);
        public void InsertFirst(object o);
        public void InsertLast(object o);
        public object Remove(object o);
        public object AtRank(int r);
        public int RankOf(object o);
    }
}
