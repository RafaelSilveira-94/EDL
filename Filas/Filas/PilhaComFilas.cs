using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pilhas;

namespace Filas
{
    internal class PilhaComFilas : IFila
    {
        public object[] p1;
        public object[] p2;
        int i = 0;
        int t1 = 0;
        int t2 = 0;
        int f = 0; //corresponde a p2
        public void Enfileirar(object o)
        {
            p2[i] = o;
            i++;
            t2++;
            while(t1 > 0)
            {
                p2[i] = p1[f];
                p1.Desinfileirar();
                f++;
                t1--;
                t2++;
            }
            f = 0;
            object[] p3;
            p3 = p1;
            p1 = p2;
            p2 = p3;
        }
        public object Desinfileirar()
        {
            if(t1 == 0)
            {
                throw new FilaVaziaException("A pilha está vazia");
            }
            object a = p2[f];
            p2[f] = null;
            f++;
            t2--;
            return a;
        }
        public object First
        {
            get
            {
                return p1[0];
            }
        }
        public int Size
        {
            get
            {
                return p1.Length;
            }
        }
        public bool IsEmpty()
        {
            if (t1 == 0) return true;
            return false;
        }
    }
}
