using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLShape;
using System.Windows.Media;
using CLMathUtil;

namespace Dossier1
{
    class Program
    {
        static void Main(string[] args)
        {
            POI poi = new POI();

            /*List<Coordonnees> coords = new List<Coordonnees>();
            coords.Add(new Coordonnees(0, 0));
            coords.Add(new Coordonnees(0, 1));
            coords.Add(new Coordonnees(0, 2));

            Polygon poly = new Polygon(coords,3);
            //poly.Draw();
            //poly.IsPointClose(poly.Coordonnees[0], 2);
            Console.WriteLine(MathUtilClass.DistanceBetween(-3, -2, -1, -3));*/

            Coordonnees coords = new Coordonnees(-3, -2);
            Coordonnees coords1 = new Coordonnees(-1,-3);

            if (poi.IsPointClose(coords1, -1))
            {
                Console.WriteLine("proche");
            }
            else
                Console.WriteLine("pas proche");


            Console.ReadKey();
        }
    }
}
