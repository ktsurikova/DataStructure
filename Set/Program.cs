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

            ////Set<Point>.IteratorSet iteratorSet = set2.GetIterator();
            //foreach (var t in set2)
            //{
            //    Console.WriteLine(t);
            //}
            //while (iteratorSet.MoveNext())
            //{
            //    Console.WriteLine(iteratorSet.Current);
            //}
            //iteratorSet.Reset();
            //set2.Add(new Point(8, 8));
            ////while (iteratorSet.MoveNext())
            ////{
            ////    Console.WriteLine(iteratorSet.Current);
            ////}

            //List<Point> list = new List<Point> {
            //    new Point { X = 1, Y = 1 },
            //    new Point { X = 4, Y = 1 },
            //    new Point { X = 1, Y = 1 },
            //    new Point { X = 1, Y = 4 },
            //    new Point { X = 3, Y = 3 },
            //    new Point { X = 1, Y = 1 }
            //};

            //Set<Point> set4 = new Set<Point>(list);
            //Console.WriteLine(set4);

            Set<Point> set1 = new Set<Point>
            {
                new Point { X = 1, Y = 1 },
                new Point { X = 1, Y = 2 },
                new Point { X = 1, Y = 3 },
                new Point { X = 1, Y = 3 },
                new Point { X = 1, Y = 4 },
                new Point { X = 1, Y = 5 },
                new Point { X = 1, Y = 6 },
                new Point { X = 1, Y = 7 },
                new Point { X = 1, Y = 8 },

            };
            Console.WriteLine(set1);

            //set1.UnionWith(new[]
            //{
            //    new Point { X = 1, Y = 1 },
            //    new Point { X = 1, Y = 2 },
            //    new Point { X = 1, Y = 3 },
            //    new Point { X = 1, Y = 9 }
            //});

            //set1.IntersectWith(new[]
            //{
            //    new Point { X = 1, Y = 1 },
            //    new Point { X = 1, Y = 2 },
            //    new Point { X = 1, Y = 3 },
            //    new Point { X = 1, Y = 9 }
            //});

            //set1.ExceptWith(new[]
            //{
            //    new Point { X = 1, Y = 1 },
            //    new Point { X = 1, Y = 2 },
            //    new Point { X = 1, Y = 3 },
            //    new Point { X = 1, Y = 9 }
            //});

            //set1.SymmetricExceptWith(new[]
            //{
            //    new Point { X = 1, Y = 1 },
            //    new Point { X = 1, Y = 2 },
            //    new Point { X = 1, Y = 3 },
            //    new Point { X = 1, Y = 9 }
            //});
            //set1.Clear();
            //Console.WriteLine(set1);

            Set<Point> emptySet = new Set<Point>();

            Console.WriteLine(set1.IsSubsetOf(new Point[0]));
            Console.WriteLine(emptySet.IsSubsetOf(set1));
            Console.WriteLine(
                new Set<Point>
                {
                        new Point { X = 1, Y = 1 },
                        new Point { X = 1, Y = 9 },
                        new Point { X = 1, Y = 3 }
                }.IsSubsetOf(set1)
                );

            Console.WriteLine(set1.IsSupersetOf(emptySet));
            Console.WriteLine(
                set1.IsSupersetOf(new Set<Point>
                {
                    new Point { X = 1, Y = 1 },
                    new Point { X = 1, Y = 2 },
                    new Point { X = 1, Y = 3 }
                })
                );
            Console.WriteLine(set1.IsSubsetOf(set1));
            Console.WriteLine(set1.IsSupersetOf(set1));

            Console.WriteLine(set1.IsProperSubsetOf(set1));
            Console.WriteLine(set1.IsProperSupersetOf(set1));
            Console.WriteLine(set1.IsProperSupersetOf(emptySet));
            Console.WriteLine(emptySet.IsProperSubsetOf(set1));

            Console.WriteLine(set1.Overlaps(new Set<Point>
                {
                    new Point { X = 1, Y = 88 },
                    new Point { X = 1, Y = 9 },
                    new Point { X = 1, Y = 3 }
                }));
            Console.WriteLine(set1.Overlaps(set1));

            Console.WriteLine(set1.SetEquals(set1));
            Console.WriteLine(set1.SetEquals(new[]
            {
                new Point { X = 1, Y = 1 },
                new Point { X = 1, Y = 2 },
                new Point { X = 1, Y = 3 },
                new Point { X = 1, Y = 4 },
                new Point { X = 1, Y = 5 },
                new Point { X = 1, Y = 6 },
                new Point { X = 1, Y = 7 },
                new Point { X = 1, Y = 8 }

            }));
            Console.WriteLine(set1.SetEquals(new Set<Point>
            {
                new Point { X = 1, Y = 1 },
                new Point { X = 1, Y = 2 },
                new Point { X = 1, Y = 4 },
                new Point { X = 1, Y = 5 },
                new Point { X = 1, Y = 6 },
                new Point { X = 1, Y = 7 },
                new Point { X = 1, Y = 8 },

            }));


            //Point[] arrPoints = new Point[9];
            //set1.CopyTo(arrPoints, 5);
            //foreach (var item in arrPoints)
            //{
            //    Console.WriteLine(item);
            //}

            //Set<Point> set2 = (Set<Point>)set1.Clone();
            //Console.WriteLine(set2);
            //set1.Remove(new Point(1, 1));
            //Console.WriteLine(set1);
            //Console.WriteLine(set2);

            Console.ReadLine();
        }
    }
}
