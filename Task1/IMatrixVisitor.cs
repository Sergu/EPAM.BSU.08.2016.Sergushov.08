using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface IMatrixVisitor<T>
    {
        IMatrix<T> Visit<T>(SymmetricMatrix<T> matrix1, DiagonalMatrix<T> matrix2);
        IMatrix<T> Visit<T>(DiagonalMatrix<T> matrix1,SymmetricMatrix<T> matrix2);
        IMatrix<T> Visit<T>(SquareMatrix<T> matrix1, DiagonalMatrix<T> matrix2);
        IMatrix<T> Visit<T>(DiagonalMatrix<T> matrix1, SquareMatrix<T> matrix2);
        IMatrix<T> Visit<T>(SymmetricMatrix<T> matrix1, SquareMatrix<T> matrix2);
        IMatrix<T> Visit<T>(SquareMatrix<T> matrix1, SquareMatrix<T> matrix2);
        IMatrix<T> Visit<T>(SquareMatrix<T> matrix1, SymmetricMatrix<T> matrix2);
    }
}
