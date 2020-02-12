using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLShape;
using System.Windows.Media;

namespace Dossier1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*POI coord1 = new POI();
            POI coord2 = new POI("test",20,20);
            Console.WriteLine(coord1);
            Console.WriteLine(coord2);*/
            List<Coordonnees> coords = new List<Coordonnees>();
            coords.Add(new Coordonnees(0, 0));
            coords.Add(new Coordonnees(0, 1));
            coords.Add(new Coordonnees(0, 2));

            Polygon poly = new Polygon(coords,3);
            Console.WriteLine(poly);
            poly.IsPointClose(poly.Coordonnees[0], 2);

            Console.ReadKey();
        }
    }
}
