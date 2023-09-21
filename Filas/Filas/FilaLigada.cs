using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Filas;

namespace Filas
{
    public class FilaLigada<T> : IFila
    {
        private Node<T> primeiro;
        private Node<T> ultimo;
        private int Tamanho = 0;
        
        public FilaLigada()
        {
            primeiro = null;
            ultimo = null;
        }
        public bool IsEmpty()
        {
            if (primeiro == null) { return true; }
            return false;
        }
        public Object First
        {
            get
            {
                if (IsEmpty())
                {
                    throw new FilaVaziaException("A pilha está vazia");
                }
                return primeiro;
            }
        }
        public int Size
        {
            get { return Tamanho; }
        }
        public void Enfileirar(object o) 
        {
            T value = (T)Convert.ChangeType(o, typeof(T));
            Node<T> newNode = new Node<T>(value);
            if(ultimo == null)
            {
                ultimo = newNode;
                primeiro = newNode;
            }
            else
            {
                ultimo.Next = newNode;
                ultimo = newNode;
            }
            Tamanho++;
        }
        public Object Desinfileirar()
        {
            if(primeiro == null)
            {
                throw new FilaVaziaException("A fila está vazia.");
            }
            if(Tamanho == 1)
            {
                object ValueTemporario = primeiro.Value;
                Tamanho--;
                primeiro = null;
                ultimo = null;
                return ValueTemporario;
            }
            if(Tamanho == 2)
            {
                object ValueTemporario = primeiro.Value;
                object NextTemporario = primeiro.Next;
                primeiro.Next = null;
                ultimo = primeiro;
                Tamanho--;
                return ValueTemporario;
            }
            object ValueTemp = primeiro.Value;
            object NextTemp = primeiro.Next;
            primeiro.Next = primeiro;
            Tamanho--;
            return ValueTemp;
        }

    }
}
