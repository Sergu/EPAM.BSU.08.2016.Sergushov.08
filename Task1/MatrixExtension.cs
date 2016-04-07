using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class MatrixExtension
    {
        public static IMatrix<T> GetSum<T>(this IMatrix<T> matrix1, IMatrix<T> matrix2)
        {
            if (ReferenceEquals(matrix1, null))
                throw new NullReferenceException();
            IMatrixVisitor<T> visitor = new CalcMatrixSumVisitor<T>();
            return matrix1.Accept<T>(visitor, matrix2);
        }
    }
}
