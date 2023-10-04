using System;
using System.Collections.Generic;
using System.Text;

namespace TadVetor
{
    public class VetorVazioException : Exception
    {
        public VetorVazioException(string message) : base(message) { }
    }
}