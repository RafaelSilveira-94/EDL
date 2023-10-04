using System;
using System.Numerics;
using Tad_Vetor;

namespace TadVetor
{
    class program
    {
        static void Main(string[] args)
        {
            VetorArray vetor = new VetorArray(20);

            Console.WriteLine(vetor.Size());
            int i = 0;
            while(i<12)
            {
                vetor.InsertAtRank(i,i); 
                i = i+1;
            }
            Console.WriteLine(vetor.Size());
            Console.WriteLine(vetor.ElemAtRank(6));
            Console.WriteLine(vetor.ReplaceAtRank(4,678));
            int a = 0;
            while(vetor.IsEmpty() != true)
            {
                Console.WriteLine(vetor.RemoveAtRank(a));
                
            }
            VetorLigado<object> vetor1 = new VetorLigado<object>();
            vetor1.InsertFirst(23);
            
        }
        

    }
}