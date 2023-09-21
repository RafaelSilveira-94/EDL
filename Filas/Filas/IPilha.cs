using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilhas
{
    public interface IPilha
    {
        int Size { get; }
        bool IsEmpty();
        Object Top { get; }
        void Push(Object o);
        Object Pop();
    }
}
