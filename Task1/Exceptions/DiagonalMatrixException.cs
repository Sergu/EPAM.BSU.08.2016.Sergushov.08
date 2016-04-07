using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Exceptions
{
    public class DiagonalMatrixException : Exception
    {
        public string Message { get; private set; }
        public DiagonalMatrixException(string message)
        {
            this.Message = message;
        }
    }
}
