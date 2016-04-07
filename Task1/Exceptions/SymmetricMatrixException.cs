using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Exceptions
{
    public class SymmetricMatrixException : Exception
    {
        public string Message { get; private set; }
        public SymmetricMatrixException(string message)
        {
            this.Message = message;
        }
    }
}
