using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class DefaultComparator<T> : IComparer<T>
    {
        public int Compare(T x,T y)
        {
            return x.GetHashCode().CompareTo(y.GetHashCode());
        }
    }
}
