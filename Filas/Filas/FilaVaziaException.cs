using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filas
{
    public class FilaVaziaException : Exception
    {
        public FilaVaziaException(string message) : base(message) { }
    }
}
