using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace ConsoleApplication
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //IMatrix<Rectangle> m1 = new SquareMatrix<Rectangle>(2);
            //m1[0, 0] = new Rectangle(3, 4);
            //m1[1, 0] = new Rectangle(5, 3);
            //m1[0, 1] = new Rectangle(9, 2);
            //IMatrix<Rectangle> m2 = new SquareMatrix<Rectangle>(2);
            //m2[0, 1] = new Rectangle(1, 3);
            //m2[0, 0] = new Rectangle(1, 1);
            //IMatrix<Rectangle> m3 = m1.GetSum(m2);
            Rectangle[,] arr = new Rectangle[2,2];
            arr[0,0] = new Rectangle(0,0);
            arr[1,1] = new Rectangle(1,1);
            arr[0,1] = new Rectangle(0,1);
            arr[1,0] = new Rectangle(0,1);


                IMatrix<Rectangle> matrix = new SymmetricMatrix<Rectangle>(arr);
               int a = matrix.Length;
               matrix = new SquareMatrix<Rectangle>();
               matrix[1, 2] = new Rectangle(1,3);

            Console.ReadLine();
        }
    }
}
