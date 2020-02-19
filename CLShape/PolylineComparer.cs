using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLShape
{
    public class PolylineComparer : IComparer<Polyline>
    {
        public int Compare(Polyline x, Polyline y)
        {
            return x.CompareTo(y);
        }
    }
}
