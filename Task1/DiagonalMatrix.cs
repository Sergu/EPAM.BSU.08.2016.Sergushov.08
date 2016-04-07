using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Exceptions;

namespace Task1
{
    public class DiagonalMatrix<T> : SymmetricMatrix<T>
    {
        private T[][] arr;
        public  DiagonalMatrix(T[] matrix)
            :base(1)
        {
            if (ReferenceEquals(matrix, null))
                throw new NullReferenceException();
            arr = new T[matrix.Length][];
            for (int i = 0; i < matrix.Length;i++ )
            {
                arr[i] = new T[1];
                arr[i][0] = matrix[i];
            }
        }
        public DiagonalMatrix(int length)
            :base(1)
        {
            arr = new T[length][];
            for (int i = 0; i < length; i++)
            {
                arr[i] = new T[1];
            }
        }
        public override int Length { get { return arr.Length; } }
        public override T this[int i,int j]
        {
            get
            {
                if (i < 0 || i >= Length || j < 0 || j >= Length)
                    throw new DiagonalMatrixException("index out of range");
                if (i == j)
                    return arr[i][0];
                else
                    return default(T);              
            }
            set
            {
                if (i < 0 || i >= Length || j < 0 || j >= Length)
                    throw new DiagonalMatrixException("index out of range");
                if (i == j)
                    arr[i][0] = value;
                else
                    throw new DiagonalMatrixException("only main diagonal can be changed");
            }
        }
    }
}
