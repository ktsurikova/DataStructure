using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SetCollection;

namespace ConApp
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point()
        {
            
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            Point point = obj as Point;
            if (point == null) return false;
            return (point.X == this.X && point.Y == this.Y);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }
    }
}
