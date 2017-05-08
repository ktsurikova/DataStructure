using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackCollection;

namespace ConAppStack
{
    class Program
    {
        static void Main(string[] args)
        {
            //ctors
            //Stack<Point> stack = new Stack<Point>(new[]
            //{
            //    new Point(1,1),
            //    new Point(3,4),
            //    null,
            //    new Point(1,1)
            //});

            Stack<Point> stack = new Stack<Point>();

            //Push
            stack.Push(new Point(1, 1));
            stack.Push(new Point(1, 2));
            stack.Push(new Point(1, 1));
            stack.Push(null);
            stack.Push(new Point(1, 3));
            stack.Push(new Point(1, 1));
            stack.Push(new Point(1, 5));

            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine(stack.Pop());
            //Console.WriteLine("3 elements removed");

            //Console.WriteLine(stack.Peek());
            //Console.WriteLine(stack.Peek());

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }


            //Console.WriteLine("Array of points");
            //Point[] pointArr = stack.ToArray();
            //foreach (var item in pointArr)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("CopyTo method");
            //Point[] points = new Point[9];
            //stack.CopyTo(points,4);
            //foreach (var item in points)
            //{
            //    Console.WriteLine(item);
            //}

            //stack.TrimExcess();

            ////toString
            //Console.WriteLine(stack);

            //Count
            Console.WriteLine("Count {0}",stack.Count);

            //stack.Clear();

            ////Contains
            //Console.WriteLine(stack.Contains(null));
            //Console.WriteLine(stack.Contains(new Point(1,1)));

            //Stack<int> stackInt = new Stack<int>();
            //stackInt.Push(1);
            //stackInt.Push(2);
            //stackInt.Push(3);
            //stackInt.Push(4);
            //stackInt.Push(5);

            //foreach (var item in stackInt)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("one element removed");
            //stackInt.Pop();
            //foreach (var item in stackInt)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(stackInt.Contains(2));

            Console.ReadLine();
        }
    }
}
