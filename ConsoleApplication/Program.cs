using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;
using Task2;

namespace ConsoleApplication
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //int[,] arr1 = new int[2,2] {{2,3},{3,5}};
            //int[] arr2 = new int[2] {10,20};
            //IMatrix<int> a = new DiagonalMatrix<int>(arr2);
            //a[0, 1] = 6;                

            //Rectangle[,] arr = new Rectangle[2,2];
            //arr[0,0] = new Rectangle(0,0);
            //arr[1,1] = new Rectangle(1,1);
            //arr[0,1] = new Rectangle(0,1);
            //arr[1,0] = new Rectangle(0,1);

            //IMatrix<Rectangle> matrix = new SymmetricMatrix<Rectangle>(arr);

            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Insert(4);
            tree.Insert(3);
            tree.Insert(9);
            tree.Insert(10);
            tree.Insert(9);



            Console.ReadLine();
        }
    }
}
