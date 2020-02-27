using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLShape
{
    public class CartoComparer : IComparer<CartoObj>
    {
        public int Compare(CartoObj x, CartoObj y)
        {
            if (x is IPointy && y is IPointy)
            {
                IPointy ip1 = x as IPointy;
                IPointy ip2 = y as IPointy;
                
                 return ip1.NbPoints.CompareTo(ip2.NbPoints);
            }
            else
                return -1;
        }
    }
}
