using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConApp;

namespace ConAppBSTs
{
    class PointComparer : IComparer<Point>
    {
        int IComparer<Point>.Compare(Point p1, Point p2)
        {
            return p1.X.CompareTo(p2.X);
        }
    }
}
