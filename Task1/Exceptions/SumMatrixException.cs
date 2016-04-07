using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class SumMatrixException : Exception
    {
        public string Message { get; private set; }
        public SumMatrixException(string message)
        {
            this.Message = message;
        }
    }
}
