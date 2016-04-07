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
            tree.Insert(1);
            Output(tree);

            BinaryTree<string> treeString = new BinaryTree<string>();
            treeString.Insert("vegetables");
            treeString.Insert("dog");
            treeString.Insert("cat");
            treeString.Insert("dog");
            treeString.Insert("mouth");
            treeString.Insert("gav-gav");
            Output(treeString);
            treeString.Remove("dog");
            Output(treeString);

            BinaryTree<Book> treeBook = new BinaryTree<Book>();
            BookComparer comparator = new BookComparer();
            Book[] bookArray = new Book[] {
                new Book(100),
                new Book(67),
                new Book(34),
                
            };
            for (int i = 0; i < bookArray.Length;i++ )
            {
                treeBook.Insert(bookArray[i],comparator);
            }
            Output(treeBook);
            //Console.WriteLine(treeBook.Find(new Book(47),comparator).Data);
            Console.WriteLine(" book amount:" + treeBook.GetElementsAmount());
            treeBook.Remove(bookArray[1],comparator);
            Console.WriteLine(" book amount after removing: " + treeBook.GetElementsAmount());
            Output(treeBook);

            Console.ReadLine();
        }
        private static void Output<T>(BinaryTree<T> node)
        {
            Console.WriteLine("outputing ----------------------------------------");
            Console.Write("preorder: ");
            foreach (T i in node.Preorder())
            {
                Console.Write("{0} ", i.ToString());
            }
            Console.WriteLine();
            Console.Write("inorder: ");
            foreach (T i in node.Inorder())
            {
                Console.Write("{0} ", i.ToString());
            }
            Console.WriteLine();
            Console.Write("postorder: ");
            foreach (T i in node.PostOrder())
            {
                Console.Write("{0} ", i.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------");
        }
    }
}
