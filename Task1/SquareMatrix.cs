using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Factory;
using Task1.Exceptions;

namespace Task1
{
    public class SquareMatrix<T> : IMatrix<T>
    {
        private T[][] arr;
        //public SquareMatrix() { }
        public SquareMatrix(T[,] matrix)
        {
            if(matrix == null)
                throw new NullReferenceException();
            if(matrix.GetLength(0)!= matrix.GetLength(1))
                throw new InvalidOperationException("matrix is not squarable");
            arr = new T[matrix.GetLength(0)][];
            for (int i = 0; i < arr.Length;i++ )
            {
                arr[i] = new T[arr.Length];
                for(int j=0;j<arr[i].Length;j++)
                {
                    arr[i][j] = matrix[i,j];
                }
            }
        }
        public SquareMatrix(int length)
        {
            if (length < 1)
                throw new ArgumentException("length below 1");
            arr = new T[length][];
            for(int i=0;i<length;i++)
            {
                arr[i] = new T[length];
            }
        }
        public override T this[int i,int j]
        {
            get{
                if (i < 0 || i >= Length || j < 0 || j >= Length)
                    throw new SquareMatrixException("index out of range");
                return arr[i][j];
            }
            set{
                if (i < 0 || i >= Length || j < 0 || j >= Length)
                    throw new SquareMatrixException("index out of range");
                arr[i][j] = value;
            }
        }
        public override int Length { get { return arr.Length; } }
    }
}
