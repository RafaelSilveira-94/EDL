using pilhas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filas
{
    public class FilaComPilhas : IPilha
    {
        private object[] input;
        private object[] output;
        private int t1 = 0;
        private int i = 0;
        private int t2 = 0;
        public FilaComPilhas()
        {
            input = new object[10];
            output = new object[10];
        }
        public int Size
        {
            get { return t1 + t2; }
        }
        private void Resize()
        {
            int newCapacity = input.Length * 2;
            object[] newArray = new object[newCapacity];
            Array.Copy(input, newArray, input.Length);
            input = newArray;

            object[] newArray2 = new object[newCapacity];
            Array.Copy(output, newArray2, output.Length);
            output = newArray2;
            i= 0;
        }
        public bool IsEmpty()
        {
            if (t1 + t2 == 0) return true;
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
                if(output.Length == 0) { return input[-1]; }
                return output[0];
            }
        }
        public void Push(object x)
        {
            if (t1 == input.Length)
            {
                Resize();
            }
            t1++;
            input[t1] = x;
        }
        public object Pop()
        {
            if (IsEmpty())
            {
                throw new FilaVaziaException("A fila está vazia");
            }
            if(t2 == 0) 
            {
                Array.Copy(input, output, input.Length);
                t2 = t1;
                t1 = 0;
            }
            object temporario = output[i];
            output[i] = null;
            t2--;
            i++;
            return temporario;
        }
    }
}
