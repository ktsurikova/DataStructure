using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTreeCollection;
using ConApp;

namespace ConAppBSTs
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(new PointComparer());
            tree.Add(new Point(6,1));
            tree.Add(new Point(10,1));
            tree.Add(new Point(4,1));
            tree.Add(new Point(1,1));
            tree.Add(new Point(5,1));
            tree.Add(new Point(8, 1));
            tree.Add(new Point(12, 1));
            //tree.Print();
            //tree.Remove(new Point(5, 1));
            //tree.Print();
            //foreach (var item in tree)
            //{
            //    Console.WriteLine(item);
            //}


            Point[] p = new Point[10];
            tree.CopyTo(p,5,TraversalMethods.InOrder);
            foreach (var item in p)
            {
                Console.WriteLine(item); 
            }
            Console.WriteLine(tree.Count);

            Console.ReadLine();
        }

    }
}
