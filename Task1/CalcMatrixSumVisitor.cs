using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Factory;
using Task1.Exceptions;

namespace Task1
{
    public class CalcMatrixSumVisitor<T> : IMatrixVisitor<T>
    {
        public static Dictionary<Type, IFactory<T>> matrixFactory = new Dictionary<Type, IFactory<T>>()
        {
            { new SquareMatrix<T>(1).GetType(),new SquareMatrixFactory<T>() },
            { new SymmetricMatrix<T>(1).GetType(),new SymmetricMatrixFactory<T>() },
            { new DiagonalMatrix<T>(1).GetType(),new DiagonalMatrixFactory<T>()}
        };
        public IMatrix<T> Visit<T>(SymmetricMatrix<T> matrix1, DiagonalMatrix<T> matrix2)
        {
            return Sum(matrix1, matrix2);
        }
        public IMatrix<T> Visit<T>(DiagonalMatrix<T> matrix1,SymmetricMatrix<T> matrix2)
        {
            return Visit(matrix2, matrix1);
        }
        public IMatrix<T> Visit<T>(SquareMatrix<T> matrix1, DiagonalMatrix<T> matrix2)
        {
            return Sum(matrix1,matrix2);
        }
        public IMatrix<T> Visit<T>(DiagonalMatrix<T> matrix1, SquareMatrix<T> matrix2)
        {
            return Visit(matrix2,matrix1);
        }
        public IMatrix<T> Visit<T>(SymmetricMatrix<T> matrix1, SquareMatrix<T> matrix2)
        {
            return Visit(matrix2, matrix1);
        }
        public IMatrix<T> Visit<T>(SquareMatrix<T> matrix1, SymmetricMatrix<T> matrix2)
        {
            return Sum(matrix1,matrix2);
        }
        public IMatrix<T> Visit<T>(SquareMatrix<T> matrix1, SquareMatrix<T> matrix2)
        {
            return Sum(matrix1,matrix2);
        }
        private IMatrix<T> MatrixAdd<T>(IMatrix<T> matrix1, IMatrix<T> matrix2)
        {

            if (ReferenceEquals(matrix1, null) || ReferenceEquals(matrix2, null))
            {
                if ((ReferenceEquals(matrix1, null) && ReferenceEquals(matrix2, null)))
                    return null;
                if (ReferenceEquals(matrix2, null))
                    return matrix1;
                else
                    return null;
            }
            else
                if (matrix1.Length == matrix2.Length)
                {
                    //SquareMatrix<T> resMatrix = new SquareMatrix<T>(matrix1.Length);
                    IMatrix<T> resMatrix = matrixFactory[matrix1.GetType()].GetInstanse<T>(matrix1.Length);
                    for (int i = 0; i < resMatrix.Length; i++)
                    {
                        for (int j = 0; j < resMatrix.Length; j++)
                        {
                            var a = (dynamic)matrix1[i, j];
                            var b = (dynamic)matrix2[i, j];
                            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                            {
                                if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                                    resMatrix[i, j] = default(T);
                                else
                                {
                                    if (ReferenceEquals(a, null))
                                        resMatrix[i, j] = b;
                                    else
                                        resMatrix[i, j] = a;
                                }
                            }
                            else
                                resMatrix[i, j] = a + b;
                        }
                    }
                    return resMatrix;
                }
                else
                    throw new ArgumentException();
        }
        private IMatrix<T> Sum<T>(IMatrix<T> matrix1, IMatrix<T> matrix2)
        {
            try
            {
                return MatrixAdd<T>(matrix1, matrix2);
            }
            catch (ArgumentException ex)
            {
                throw new SumMatrixException("different matrix size");
            }
            catch (Exception ex)
            {
                throw new SumMatrixException(ex.Message);
            }
        }
    }
}
