using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetCollection;

namespace ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Set<Point> set1 = new Set<Point>(
                new Point { X = 3, Y = 1 },
                new Point { X = 1, Y = 3 },
                new Point { X = 2, Y = 1 },
                new Point { X = 1, Y = 1 },
                new Point { X = 1, Y = 2 },
                new Point { X = 1, Y = 1 },
                new Point { X = 1, Y = 1 },
                new Point { X = 1, Y = 1 }
                );

            Set<Point> set2 = new Set<Point>(
                new Point { X = 1, Y = 1 },
                new Point { X = 1, Y = 1 },
                new Point { X = 4, Y = 1 },
                new Point { X = 1, Y = 1 },
                new Point { X = 1, Y = 4 },
                new Point { X = 1, Y = 1 },
                new Point { X = 1, Y = 1 },
                new Point { X = 1, Y = 1 }
            );

            Console.WriteLine("set1 {0}",set1);
            Console.WriteLine("set2 {0}", set2);
            

            set2.UnionWith(set1);
            Console.WriteLine("set2 union with set1 \n {0}",set2);
            Console.WriteLine("is set2 subset of set1 {0}",set2.IfSubsetOf(set1));
            Console.WriteLine("is set1 subset of set2 {0}",set1.IfSubsetOf(set2));
            Set<Point>.IteratorSet iteratorSet = set2.GetIterator();
            while (iteratorSet.MoveNext())
            {
                Console.WriteLine(iteratorSet.Current);
            }
            set2.DifferenceWith(set1);
            Console.WriteLine("set2 difference with set1 \n {0}", set2);
            set2.Add(new Point(1,1));
            Console.WriteLine("element added in set2 \n {0}",set2);

            Set<Point> set3 = new Set<Point>(
                new Point { X = 1, Y = 1 },
                new Point { X = 1, Y = 1 },
                new Point { X = 4, Y = 1 },
                new Point { X = 1, Y = 1 },
                new Point { X = 1, Y = 4 },
                new Point { X = 1, Y = 1 },
                new Point { X = 1, Y = 1 },
                new Point { X = 1, Y = 1 }
            );

            Console.WriteLine("set3 {0}", set3);
            Console.WriteLine("is set2 equal to set3 {0}",set2.SetEquals(set3));

            Console.ReadLine();
        }
    }
}
