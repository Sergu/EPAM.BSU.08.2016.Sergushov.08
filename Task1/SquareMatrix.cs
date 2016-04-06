using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class A
    {
        public int field;
    }
    public class Rectangle
    {
        public int width{get;private set;}
        public int height{get;private set;}
        public Rectangle(int width,int height)
        {
            this.width = width;
            this.height = height;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            Rectangle rect = obj as Rectangle;
            if(rect != null)
            {
                if ((this.width == rect.width) && (this.height == rect.height))
                    return true;
            }
            else
                return base.Equals(obj);
            return false;
        }
        public static Rectangle operator +(Rectangle leftRect,Rectangle rRect)
        {
            if(ReferenceEquals(leftRect,null) || ReferenceEquals(rRect,null))
            {
                if(ReferenceEquals(leftRect,null) && ReferenceEquals(rRect,null))
                {
                    return new Rectangle(default(int),default(int));
                }
                else
                {
                    if(ReferenceEquals(leftRect,null))
                    {
                        return leftRect;
                    }
                    else 
                        return rRect;
                }
            }
            return new Rectangle(leftRect.width + rRect.width, leftRect.height + leftRect.height);
        }
    }
    public abstract class IMatrix<T>
    {
        public abstract T this[int i, int j]
        {
            get;
            set;
        }
        public abstract int Length { get; }
        public IMatrix<T> Accept<T>(IMatrixVisitor visitor, IMatrix<T> matrix)
        {
            return visitor.Visit<T>((dynamic)this,(dynamic)matrix);
        }
    }
    public interface IMatrixVisitor
    {
        IMatrix<T> Visit<T>(SquareMatrix<T> matrix1, SquareMatrix<T> matrix2);

    }
    public class CalcMatrixSumVisitor: IMatrixVisitor
    {
        //public IMatrix<T> Vistit<T>(SquareMatrix<T>matrix1, SymmetricMatrix<T> matrix2)
        //{

        //}
        public IMatrix<T> Visit<T>(SquareMatrix<T> matrix1, SquareMatrix<T> matrix2)
        {
            try
            {
                if (matrix1.Length == matrix2.Length)
                {
                    SquareMatrix<T> resMatrix = new SquareMatrix<T>(matrix1.Length);
                    for(int i =0;i<resMatrix.Length;i++)
                    {
                        for(int j=0;j<resMatrix.Length;j++)
                        {
                            var a = (dynamic)matrix1[i, j];
                            var b = (dynamic)matrix2[i, j];
                            resMatrix[i,j] = a + default(Rectangle);
                        }
                    }
                    return resMatrix;
                }
                else
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
    public static class MatrixExtension
    {
        public static IMatrix<T> GetSum<T>(this IMatrix<T> matrix1,IMatrix<T> matrix2)
        {
            IMatrixVisitor visitor = new CalcMatrixSumVisitor();
            return matrix1.Accept<T>(visitor,matrix2);
        }
    }
    public class SquareMatrix<T> : IMatrix<T>
    {
        private T[,] arr;
        public SquareMatrix() { }
        public SquareMatrix(T[,] arr)
        {
            if (arr.GetLength(0) != arr.GetLength(0))
                throw new InvalidOperationException("matrix is not squarable");
            this.arr = arr;
        }
        public SquareMatrix(int length)
        {
            arr = new T[length,length];
        }
        public override T this[int i,int j]
        {
            get{
                return arr[i,j];
            }
            set{
                arr[i,j] = value;
            }
        }
        public override int Length { get { return arr.GetLength(0); } }
    }
    // Продумать хранения массива в squarematrix
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        private T[][] arr;
        public SymmetricMatrix(T[,] matrix)
        {
            if(SymmetricMatrixCheck<T>(matrix))
            {
                arr = new T[matrix.GetLength(0)][];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    arr[i] = new T[i + 1];
                    for(int j=0;j<=i;j++)
                    {
                        arr[i][j] = matrix[i,j];
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("unsymmetrical matrix");
            }
        }
        public SymmetricMatrix(int length)
        {
            for (int i = 0; i < length; i++)
            {
                arr[i] = new T[i]; 
            }
        }
        public override T this[int i,int j]
        {
            get
            {
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
                if (j > i)
                {
                    int temp = i;
                    i = j;
                    j = temp;
                }
                arr[i][j] = value;
            }
        }
        public override int Length { get { return arr.GetLength(0); } }
        private bool SymmetricMatrixCheck<T>(T[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(0))
                return false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j=0;j<i;j++)
                {
                    if (!((dynamic)matrix[j,i].Equals((dynamic)matrix[i,j])))
                        return false;
                }
            }
            return true;
        }
    }
}
