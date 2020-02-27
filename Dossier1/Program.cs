using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLShape;
using System.Windows.Media;
using CLMathUtil;
using MyCartoWindow;

namespace Dossier1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CartoObj> liste = new List<CartoObj>();

            Coordonnees c1 = new Coordonnees();
            liste.Add(c1);
            Coordonnees c2 = new Coordonnees(10, 20);
            liste.Add(c2);

            POI p1 = new POI();
            liste.Add(p1);
            POI p2 = new POI("test", 20, 30);
            liste.Add(p2);

            List<Coordonnees> l = new List<Coordonnees>();
            l.Add(new Coordonnees(0, 1));
            l.Add(new POI("lol", 0, 3));
            l.Add(new Coordonnees(3, 4));


            Polyline pl1 = new Polyline();
            liste.Add(pl1);
            Polyline pl2 = new Polyline(l, 3, Colors.AliceBlue);
            liste.Add(pl2);

            Polygon pol1 = new Polygon();
            liste.Add(pol1);
            Polygon pol2 = new Polygon(l, 2, Colors.ForestGreen, Colors.Aqua);
            liste.Add(pol2);

            foreach (CartoObj obj in liste)
            {
                if (obj is IPointy)
                    Console.WriteLine("Ipointy -- ");
                else
                    Console.WriteLine("Not Ipointy --");

                Console.WriteLine(obj);
                Console.WriteLine("\n");
            }

            List<Polyline> poListe = new List<Polyline>();

            poListe.Add(pl1);
            poListe.Add(pl2);

            Polyline pl3 = new Polyline();
            pl3.Coordonnees.Add(new Coordonnees(0, 5));
            poListe.Add(pl3);

            Polyline pl4 = new Polyline();
            pl4.Coordonnees.Add(new POI("lol", 0, 5));

            poListe.Add(new Polyline());
            poListe.Add(new Polyline());

            poListe.Sort();
            foreach (Polyline p in poListe)
                Console.WriteLine(p);


            PolylineComparer pc = new PolylineComparer();

            poListe.Sort(pc);
            Console.WriteLine("+++++++++++++");
            foreach (Polyline p in poListe)
                Console.WriteLine(p);

            Console.WriteLine("+++++++++++++");

            Console.WriteLine(
            poListe.Find(x => x.NbPoints == 1)
                );

            Console.WriteLine(
            poListe.FindAll(x => x.NbPoints == 1)
                );

            DisplayCartoObjCollection(
              poListe.FindAll(x => x.IsPointClose(new Coordonnees(0, 0), 1))
              );

            Console.WriteLine("--------------- ");

            CartoComparer cc = new CartoComparer();
            poListe.Sort(cc);
            DisplayCartoObjCollection(poListe);

            Console.ReadKey();

        }

        private static void DisplayCartoObjCollection(List<Polyline> poListe)
        {
            foreach (Polyline p in poListe)
                Console.WriteLine(p);
        }
    }
}
