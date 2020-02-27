using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using CLMathUtil;

namespace CLShape
{
    public class Polyline : CartoObj, IPointy, IComparable<Polyline>, IEquatable<Polyline>
    {
        #region VARIABLES
        private List<Coordonnees> _coordonnees;
        private int _epaisseur;
        private Color _couleur;
        private BoundingBox _boundingBox;

        #endregion

        #region PROPRIETES
        public BoundingBox Bbox
        {
            get { return _boundingBox;  }
            set { _boundingBox = value;  }
        }

        public Color Couleur
        {
            get { return _couleur;  }
            set { _couleur = value;  }
        }

        public List<Coordonnees> Coordonnees
        {
            get { return _coordonnees; }
            set { _coordonnees = value; }
        }

        public int Epaisseur
        {
            get { return _epaisseur; }
            set { _epaisseur = value; }
        }

        public int NbPoints
        {
            get { return _coordonnees.Count(); /* changer pour compter les ids differents */}
        }

        #endregion

        #region CONSTRUCTEURS
        public Polyline(List<Coordonnees> coordonnees, int epaisseur, Color couleur) : base()
            {
                Coordonnees = coordonnees;
                Epaisseur = epaisseur;
                Couleur = couleur;
                Bbox = new BoundingBox();
            }

        public Polyline(List<Coordonnees> coordonnees, int epaisseur) : this(coordonnees, epaisseur, Colors.Aqua) { }
        public Polyline():this(new List<Coordonnees>(),0,Colors.Aqua) { }
        #endregion

        #region METHODES
        public override string ToString()
        {
            string stringReturn = "";

            foreach (Coordonnees s in Coordonnees)
                stringReturn = stringReturn +" "+ s.ToString();

            return base.ToString() +" Couleur: "+ Couleur.ToString() +" Epaisseur: " + Epaisseur + " Coordonees: " + stringReturn;
        }


        public override void Draw()
        {
            Console.WriteLine(this.ToString());
        }

        public override bool IsPointClose(Coordonnees point, double precision)
        {
            if (NbPoints < 2)
                return false;
            Bbox.InitBbox(Coordonnees);

            if (point.Longitude < Bbox.Min.Longitude || point.Longitude > Bbox.Max.Longitude)
                return false;
            if (point.Latitude < Bbox.Min.Latitude || point.Latitude > Bbox.Max.Latitude)
                return false;

            // calculer distance entre point et les 2 extremites + mediane et considerer le plus petit
            for (int i = 0; i < Coordonnees.Count -1; i++)
            {
                double distance;
                distance = MathUtil.DistanceBetweenLine(Coordonnees[i].Longitude, Coordonnees[i].Latitude, Coordonnees[i + 1].Longitude, Coordonnees[i + 1].Latitude, point.Longitude, point.Latitude);
                if (distance < precision)
                    return true;
            }

            return false;
        }

        public double CheckDistance()
        {
            double distance = 0;
            for (int i = 0; i < Coordonnees.Count - 1; i++)
            {
                
                distance += MathUtil.DistanceBetween(Coordonnees[i].Longitude, Coordonnees[i].Latitude, Coordonnees[i + 1].Longitude, Coordonnees[i + 1].Latitude);
                   
            }
            return distance;
        }

        public int CompareTo(Polyline other)
        {
            // calcul distance
            return this.CheckDistance().CompareTo(other.CheckDistance());  
        }

        public bool Equals(Polyline other)
        {
            return this.NbPoints == other.NbPoints;
        }

        #endregion
    }
}
