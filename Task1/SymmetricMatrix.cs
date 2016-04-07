using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Exceptions;

namespace Task1
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        private T[][] arr;
        public SymmetricMatrix(T[,] matrix)
            : base(1)
        {
            if (ReferenceEquals(matrix, null))
                throw new NullReferenceException();
            if (IsSymmetricMatrix<T>(matrix))
            {
                arr = new T[matrix.GetLength(0)][];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    arr[i] = new T[i + 1];
                    for (int j = 0; j <= i; j++)
                    {
                        arr[i][j] = matrix[i, j];
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("unsymmetrical matrix");
            }
        }
        public SymmetricMatrix(int length)
            : base(1)
        {
            arr = new T[length][];
            for (int i = 0; i < length; i++)
            {
                arr[i] = new T[i + 1];
            }
        }
        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Length || j < 0 || j >= Length)
                    throw new SymmetricMatrixException("index out of range");
                if (j > i)
                {
                    int temp = i;
                    i = j;
                    j = temp;
                }
                return arr[i][j];
            }
            set
            {
                if (i < 0 || i >= Length || j < 0 || j >= Length)
                    throw new SymmetricMatrixException("index out of range");
                if (j > i)
                {
                    int temp = i;
                    i = j;
                    j = temp;
                }
                arr[i][j] = value;
            }
        }
        public override int Length { get { return arr.Length; } }
        private bool IsSymmetricMatrix<T>(T[,] matrix)
        {
            if (matrix.GetLength(1) != matrix.GetLength(0))
                return false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (!((dynamic)matrix[j, i].Equals((dynamic)matrix[i, j])))
                        return false;
                }
            }
            return true;
        }
    }
}
