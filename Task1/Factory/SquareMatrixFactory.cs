using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Factory
{
    public interface IFactory<T>
    {
        IMatrix<T> GetInstanse<T>(int length);
    }
    public class SquareMatrixFactory<T> : IFactory<T>
    {
        public IMatrix<T> GetInstanse<T>(int length)
        {
            return new SquareMatrix<T>(length);
        }
    }
    public class SymmetricMatrixFactory<T> : IFactory<T>
    {
        public IMatrix<T> GetInstanse<T>(int lenght)
        {
            return new SymmetricMatrix<T>(lenght);
        }
    }
    public class DiagonalMatrixFactory<T> : IFactory<T>
    {
        public IMatrix<T> GetInstanse<T>(int lenght)
        {
            return new DiagonalMatrix<T>(lenght);
        }
    }
}
