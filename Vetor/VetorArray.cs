using System;
using System.Collections.Generic;
using System.Text;

namespace TadVetor
{
    class VetorArray : IVetor
    {
        public object[] elements;
        int n = 0;

        public VetorArray(int capacity)
        {
            elements = new object[capacity];
        }
        public int Size()
        {
            return n;
        }
        public bool IsEmpty()
        {
            if (n == 0) return true;
            return false;
        }
        public object ElemAtRank(int r)
        {
            if (n == 0) { throw new VetorVazioException("O vetor está vazio."); }
            return elements[r];
        }
        public void InsertAtRank(int r, object e)
        {
            if (r < 0 || r > n)
            {
                throw new VetorVazioException("A posição r está fora dos limites do vetor.");
            }

            if (n >= elements.Length)
            {
                // Redimensionar a matriz se necessário
                Array.Resize(ref elements, elements.Length * 2);
            }

            for (int i = n - 1; i >= r; i--)
            {
                elements[i + 1] = elements[i];
            }
            elements[r] = e;
            n++;
        }
        public object ReplaceAtRank(int r, object o)
        {
            if (n == 0)
            {
                throw new VetorVazioException("O vetor está vazio.");
            }

            if (r < 0 || r >= n)
            {
                throw new VetorVazioException("A posição r está fora dos limites do vetor.");
            }
            object a = elements[r];
            elements[r] = o;
            return a;
        }
        public object RemoveAtRank(int r)
        {
            if (n == 0)
            {
                throw new VetorVazioException("O vetor está vazio.");
            }

            if (r < 0 || r >= n)
            {
                throw new VetorVazioException("A posição r está fora dos limites do vetor.");
            }

            object a = elements[r];

            for (int i = r; i < n - 1; i++)
            {
                elements[i] = elements[i + 1];
            }

            elements[n - 1] = null; // Limpar a última posição
            n--;
            return a;
        }
    }
}
