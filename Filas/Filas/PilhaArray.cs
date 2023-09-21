using Filas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pilhas
{
    public class PilhaArray : IPilha
    {
        private object[] elements;
        private int t = 0;
        public PilhaArray()
        {
            elements = new object[10];
        }
        public int Size
        {
            get { return t; }
        }
        private void Resize()
        {
            int newCapacity = elements.Length * 2;
            object[] newArray = new object[newCapacity];
            Array.Copy(elements, newArray, elements.Length);
            elements = newArray;
        }
        public bool IsEmpty()
        {
            if(t == 0) return true;
            return false; 
        }
        public object Top
        {
            get
            {
                if (IsEmpty())
                {
                    throw new FilaVaziaException("A fila está vazia");
                }
                return elements[t - 1];
            }
        }
        public void Push(object x)
        {
            if (t == elements.Length)
            {
                Resize();
            }
            elements[t++] = x;
        }
        public object Pop()
        {
            if (IsEmpty())
            {
                throw new FilaVaziaException("A fila está vazia");
            }
            object primeiro = elements[t - 1];
            elements[t - 1] = null;
            t--;
            return primeiro;
        }
    }
}
