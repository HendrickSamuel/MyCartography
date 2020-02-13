using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLMathUtil
{
    public static class MathUtil
    {
        public static double DistanceBetween(double x1, double y1, double x2, double y2 )
        {
            double a = Math.Abs(x1) + Math.Abs(x2);
            double b = Math.Abs(y1) + Math.Abs(y2);
            double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            return c;
        }
    }
}
