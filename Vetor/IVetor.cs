using System;
using System.Collections.Generic;
using System.Text;

namespace TadVetor
{
    public interface IVetor
    {
        int Size();
        bool IsEmpty();
        object ElemAtRank(int r);
        object ReplaceAtRank(int r, object e);
        void InsertAtRank(int r, object e);
        object RemoveAtRank(int r);
    }
}
