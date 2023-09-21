using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Filas;

namespace pilhas
{
    public class PilhaLigada<T> : IPilha
    {
        private Node<T> primeiro;
        private int Tamanho = 0;
        public PilhaLigada()
        {
            primeiro = null;
        }
        public int Size
        {
            get { return Tamanho; }
        }
        public bool IsEmpty()
        {
            if (Tamanho == 0) return true;
            return false;
        }
        public object Top
        {
            get { return primeiro; }
        }
        public void Push(object o)
        {
            T value = (T)Convert.ChangeType(o, typeof(T));
            Node<T> newNode = new Node<T>(value);
            newNode.Next = primeiro;
            primeiro = newNode;
            Tamanho++;
        }
        public object Pop()
        {
            object valuetemp = primeiro.Value;
            primeiro = primeiro.Next;
            return valuetemp;
        }
    }
}
