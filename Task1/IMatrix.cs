using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public abstract class IMatrix<T>
    {
        public abstract T this[int i, int j]
        {
            get;
            set;
        }
        public abstract int Length { get; }
        public IMatrix<T> Accept<T>(IMatrixVisitor<T> visitor, IMatrix<T> matrix)
        {
            return visitor.Visit<T>((dynamic)this, (dynamic)matrix);
        }
    }
}
