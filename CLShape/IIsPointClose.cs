using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLShape
{
    public interface IIsPointClose
    {
        bool IsPointClose(Coordonnees coordonnees, double Precision);
    }
}
