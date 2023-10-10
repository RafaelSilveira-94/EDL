using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sequencia
{
    public class SequenciaListaLigada<T> : ISequencia
    {
        private Node<T>? primeiro;
        private Node<T>? ultimo;
        private int Tamanho = 0;
        private int i = 0;
        public SequenciaListaLigada()
        {
            primeiro = null;
            ultimo = null;
        }
        public int Size()
        {
            return Tamanho;
        }
        public bool IsEmpty()
        {
            if (Tamanho == 0) return true;
            return false;
        }
        public object First()
        {
            if (Tamanho == 0) throw new ArgumentException("A sequencia está vazia.");
            return primeiro;
        }
        public object Last()
        {
            if (Tamanho == 0) throw new ArgumentException("A sequencia está vazia.");
            return ultimo;
        }
        public object ElemAtRank(int r)
        {
            Node<T> iterador = primeiro;
            while (i <= r)
            {
                if (i == r) { return iterador.Value; }
                i++;
                iterador = iterador.Next;
            }
            throw new ArgumentException("Não existe esse indice na sequência.");
        }
        public object Before(object o)
        {
            if (Tamanho == 0) throw new ArgumentException("Vetor está vazio.");
            Node<T> iterador = primeiro;
            Node<T> anterior = null;
            while (iterador != null)
            {
                if (iterador.Value.Equals(o))
                {
                    if (anterior == null) { return null; }
                    else { return anterior.Value; }
                }
                anterior = iterador;
                iterador = iterador.Next;
            }
            throw new ArgumentException("Não existe o objeto n na lista.");
        }
        public object After(object o)
        {
            if (Tamanho == 0) throw new ArgumentException("Vetor está vazio.");
            Node<T> iterador = primeiro;
            Node<T> proximo = primeiro.Next;
            while (proximo != null)
            {
                if (iterador.Value.Equals(o))
                {
                    if (proximo == null) { return null; }
                    else { return proximo.Value; }
                }
                proximo = proximo.Next;
                iterador = iterador.Next;
            }
            throw new ArgumentException("Não existe o objeto n na lista.");
        }
        public object ReplaceAtRank(int r, object o)
        {
            Node<T> iterador = primeiro;
            while (i <= r)
            {
                if (i == r)
                {
                    object a = iterador.Value;
                    iterador.Value = (T?)o;
                    return a;
                }
                i++;
                iterador = iterador.Next;
            }
            throw new ArgumentException("Não existe esse indice na sequência.");
        }
        public void InsertAtRank(int r, object o)
        {
            Node<T> iterador = primeiro;
            while (i <= r)
            {
                if (i == r)
                {
                    iterador.Value = (T?)o;
                }
                i++;
                iterador = iterador.Next;
            }
            throw new ArgumentException("Não existe esse indice na sequência.");
        }

        public object RemoveAtRank(int r)
        {
            Node<T> iterador = primeiro;
            while (i <= r)
            {
                if (i == r)
                {
                    iterador.Next.Prev = iterador.Prev;
                    iterador.Prev.Next = iterador.Next;
                    object a = iterador.Value;
                    iterador = null;
                    return a;
                }
                i++;
                iterador = iterador.Next;
            }
            throw new ArgumentException("Não existe esse indice na sequência.");
        }
        public object ReplaceElement(object n, object o)
        //o objeto n será o objeto a ser substituído e o "o" substituirá.
        {
            if (Tamanho == 0) throw new ArgumentException("Vetor está vazio.");
            Node<T> iterador = primeiro;
            while (iterador != null)
            {
                if (iterador.Value.Equals(n))
                {
                    iterador.Value = (T)o;
                    return n;
                }
                iterador = iterador.Next;
            }
            throw new ArgumentException("O objeto n não está na lista.");
        }

        public object SwapElement(object n, object o)
        {
            if (Tamanho == 0) throw new ArgumentException("Vetor está vazio.");
            Node<T> iterador1 = primeiro;
            Node<T> NodeN = null;
            Node<T> NodeO = null;

            while (iterador1 != null)
            {
                if (iterador1.Value.Equals(n))
                {
                    NodeN = iterador1;
                }
                else if (iterador1.Value.Equals(o))
                {
                    NodeO = iterador1;
                }
                iterador1 = iterador1.Next;
            }
            if (NodeN != null && NodeO != null)
            {
                T tempValue = NodeN.Value;
                NodeN.Value = NodeO.Value;
                NodeO.Value = tempValue;
            }
            throw new ArgumentException("Pelo menos um dos objetos não está na lista.");
        }
        public void InsertBefore(object n, object o)
        {
            //o objeto n será o objeto procurado e o objeto o será o inserido.
            Node<T> iterador = primeiro;
            Node<T> NodeO = null;
            while (iterador != null)
            {
                if (iterador.Value.Equals(n))
                {

                    iterador = iterador.Prev;
                    NodeO.Prev = iterador;
                    NodeO.Value = (T)o;
                    NodeO.Next = iterador.Next;
                    iterador.Next = NodeO;
                    NodeO.Next = iterador;
                    iterador.Prev = NodeO;
                    Tamanho++;
                }
                else { throw new ArgumentException("Não tem o objeto n na lista."); }
            }
        }
        public void InsertAfter(object n, object o)
        {
                //o objeto n será o objeto procurado e o objeto o será o inserido.
                Node<T> iterador = primeiro;
                Node<T> NodeO = primeiro;
                while (iterador != null)
                {
                    if (iterador.Value.Equals(n))
                    {
                        NodeO.Next = iterador.Next;
                        iterador = iterador.Next;
                        NodeO.Prev = iterador.Prev;
                        NodeO.Value = (T)o;
                        iterador.Prev = NodeO;
                        iterador = NodeO.Prev;
                        iterador.Next = NodeO;
                        Tamanho++;
                    }
                    iterador = iterador.Next;

                }
                throw new ArgumentException("Não tem o objeto n na lista.");
            }

        public void InsertFirst(object o)
            {
                Node<T> NodeN;
                if (Tamanho == 0)
                {
                    NodeN = new Node<T>((T)o);
                    primeiro = NodeN;
                    ultimo = NodeN;
                    NodeN.Value = (T)o;
                    NodeN.Next = null;
                    NodeN.Prev = null;

                }
                else
                {
                    NodeN = new Node<T>((T)o);
                    NodeN.Value = (T)o;
                    NodeN.Prev = null;
                    NodeN.Next = primeiro;
                    primeiro = NodeN;
                }
                Tamanho++;
            }

        public void InsertLast(object o)
            {
                Node<T> NodeN = null;
                if (Tamanho == 0)
                {
                    NodeN = primeiro;
                    NodeN = ultimo;
                    NodeN.Next = null;
                    NodeN.Prev = null;
                    NodeN.Value = (T)o;
                }
                else
                {
                    NodeN.Value = (T)o;
                    NodeN.Prev = ultimo;
                    NodeN.Next = null;
                    ultimo = NodeN;
                }
                Tamanho++;
            }

        public object Remove(object o)
            {
                if (Tamanho == 0) throw new ArgumentException("Vetor está vazio.");
                Node<T> iterador = primeiro;
                while (iterador != null)
                {
                    if (iterador.Value.Equals(o))
                    {
                        iterador.Next.Prev = iterador.Prev;
                        iterador.Prev.Next = iterador.Next;
                        return iterador.Value;
                    }
                }
                throw new ArgumentException("Vetor está vazio.");
            }
        public object AtRank(int r)
            {
                Node<T> iterador = primeiro;
                while (i <= r)
                {
                    if (i == r)
                    {
                        return iterador.Value;
                    }
                    i++;
                    iterador = iterador.Next;
                }
            throw new ArgumentException("Não existe esse indice na sequência.");
            }

        public int RankOf(object o)
            {
            Node<T> iterador = primeiro;
            while (iterador != null)
            {
                if (iterador.Value.Equals(o))
                {
                    return i;
                }
                i++;
                iterador = iterador.Next;
            }
            throw new ArgumentException("Não existe esse objeto na lista.");
        }
    }
}
