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
            double a = x2 - x1;
            double b = y2 - y1;
            double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            return c;
        }

        public static double DistanceBetweenLine(double x1, double y1, double x2, double y2, double x, double y)
        {
            double A = x - x1;
            double B = y - y1;
            double C = x2 - x1;
            double D = y2 - y1;

            double dot = A * C + B * D;

            double len_sq = C * C + D * D;
            double param = -1;

            if (len_sq != 0)
                param = dot / len_sq;

            double xx, yy;

            if(param < 0)
            {
                xx = x1;
                yy = y1;
            }
            else
            if(param > 1)
            {
                xx = x2;
                yy = y2;
            }
            else
            {
                xx = x1 + param * C;
                yy = y1 + param * D;
            }

            double dx = x - xx;
            double dy = y - yy;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
