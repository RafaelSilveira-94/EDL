using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TadVetor;

namespace Tad_Vetor
{
    public class VetorLigado<T> : IVetorLigado
    { 
        public Node<T>? primeiro;
        public Node<T>? ultimo;
        private int Tamanho = 0;
        public Node<T>? NodeN;

        public VetorLigado()
        {
            primeiro = null;
            ultimo = null;
            NodeN = null;
        }
        public bool IsEmpty()
        {
            if(Tamanho == 0) return true;
            return false;
        }
        public int Size()
        {
            return Tamanho;
        }
        public object First
        {
            get { return primeiro; }
        }
        public object Last
        {
            get { return ultimo; }
        }
        public object Before(object n)
        {
            if (Tamanho == 0) throw new VetorVazioException("Vetor está vazio.");
            Node<T> iterador = primeiro;
            Node<T> anterior = null;
            while (iterador != null)
            {
                if (iterador.Value.Equals(n))
                {
                    if (anterior == null) { return null; }
                    else { return anterior.Value; }
                }
                anterior = iterador;
                iterador = iterador.Next;
            }
            throw new VetorVazioException("Não existe o objeto n na lista.");
        }
        public object After(object n)
        {
            if (Tamanho == 0) throw new VetorVazioException("Vetor está vazio.");
            Node<T> iterador = primeiro;
            Node<T> proximo = primeiro.Next;
            while (proximo != null) 
            {
                if (iterador.Value.Equals(n))
                {
                    if (proximo == null) { return null; }
                    else { return proximo.Value; }
                }
                proximo = proximo.Next;
                iterador = iterador.Next;
            }
            throw new VetorVazioException("Não existe o objeto n na lista.");
        }
        public object ReplaceElement(object n, object o)
            //o objeto n será o objeto a ser substituído e o "o" substituirá.
        {
            if (Tamanho == 0) throw new VetorVazioException("Vetor está vazio.");
            Node<T> iterador = primeiro;
            while(iterador != null) 
            { 
                if (iterador.Value.Equals(n))
                {
                    iterador.Value = (T)o;
                    return o;
                }
                iterador = iterador.Next;
            }
            throw new VetorVazioException("O objeto n não está na lista.");
        }
        public void SwapElements(object n, object o)
        {
            if (Tamanho == 0) throw new VetorVazioException("Vetor está vazio.");
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
            else
            {
                throw new VetorVazioException("Pelo menos um dos objetos não está na lista.");
            }
        }
        public void InsertAfter(object n, object o)
        {
            //o objeto n será o objeto procurado e o objeto o será o inserido.
            Node<T> iterador = primeiro;
            Node<T> NodeO = primeiro;
            while(iterador != null)
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
           throw new VetorVazioException("Não tem o objeto n na lista."); 
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
                else { throw new VetorVazioException("Não tem o objeto n na lista."); }
            }
        }
        public void InsertFirst(object n)
        {
            
            if (Tamanho == 0)
            {
                NodeN = new Node<T>((T)n);
                primeiro = NodeN;
                ultimo = NodeN;
                NodeN.Value = (T)n;
                NodeN.Next = null;
                NodeN.Prev = null;
                
            }
            else
            {
                NodeN.Value = (T)n;
                NodeN.Prev = null;
                NodeN.Next = primeiro;
                primeiro = NodeN;
            }
            Tamanho++;
        }
        public void InsertLast(object n)
        {
            Node<T> NodeN = null;
            if (Tamanho == 0)
            {
                NodeN = primeiro;
                NodeN = ultimo;
                NodeN.Next = null;
                NodeN.Prev = null;
                NodeN.Value = (T)n;
            }
            else
            {
                NodeN.Value = (T)n;
                NodeN.Prev = ultimo;
                NodeN.Next = null;
                ultimo = NodeN;
            }
            Tamanho++;
        }
        public object Remove(object n)
        {
            if (Tamanho == 0) throw new VetorVazioException("Vetor está vazio.");
            Node<T> iterador = primeiro;
            while(iterador != null)
            {
                if(iterador.Value.Equals(n))
                {
                    iterador.Next.Prev = iterador.Prev;
                    iterador.Prev.Next = iterador.Next;
                    return iterador.Value;
                }
            }
            throw new VetorVazioException("Não existe o objeto n na lista.");
        }
    }
}
