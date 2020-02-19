using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using CLMathUtil;

namespace CLShape
{
    public class Polygon: CartoObj, IPointy
    {
        #region VARIABLES
        private List<Coordonnees> _coordonnees;
        private Color _contour;
        private Color _remplissage;
        private double _opacite;
        private BoundingBox _boundingBox;

        #endregion

        #region PROPRIETES
        public BoundingBox Bbox
        {
            get { return _boundingBox; }
        }
        public Color Contour
        {
            get { return _contour; }
            set { _contour = value; }
        }

        public Color Remplissage
        {
            get { return _remplissage; }
            set { _remplissage = value; }
        }

        public List<Coordonnees> Coordonnees
        {
            get { return _coordonnees; }
            set { _coordonnees = value;  }
        }

        public double Opacite
        {
            get { return _opacite; }
            set 
            {
                if (value < 0) _opacite = 0;
                else if (value > 1) _opacite = 1;
                else _opacite = value;
            }
        }

        public int NbPoints
        {
            get { return _coordonnees.Count();/* changer pour compter les ids differents */ }
        }
        #endregion

        #region CONSTRUCTEURS
        public Polygon(List<Coordonnees> coordonnees, double opacite, Color contour, Color remplissage):base()
        {
            if (coordonnees == null)
                Coordonnees = new List<Coordonnees>();
            else
                Coordonnees = coordonnees;
            Opacite = opacite;
            Remplissage = remplissage;
            Contour = contour;
        }
        public Polygon(List<Coordonnees> coordonnees, double opacite) : this(coordonnees, opacite, Colors.Black, Colors.White) { }
        public Polygon() : this(new List<Coordonnees>(), 0, Colors.Black, Colors.White) { }
        #endregion

        #region METHODES
        public override string ToString()
        {
            string stringReturn = "";

            foreach (Coordonnees s in Coordonnees)
                stringReturn = stringReturn + " " + s.ToString();

            return base.ToString() + " Opacite: " + Opacite +"\n\tFond: "+Remplissage.ToString() + " Contour: "+Contour.ToString() +"\n\tPoints: "+NbPoints+"\n\tCoordonees: " + stringReturn;
        }

        public override void Draw()
        {
            Console.WriteLine(this.ToString());
        }

        public override bool IsPointClose(Coordonnees point, double precision)
        {
            if (NbPoints == 0)
                throw new ArgumentException("La liste de polyline est vide");

            Bbox.InitBbox(Coordonnees);

            if (point.Longitude < Bbox.Min.Longitude || point.Longitude > Bbox.Max.Longitude)
                return false;
            if (point.Latitude < Bbox.Min.Latitude || point.Latitude > Bbox.Max.Latitude)
                return false;

            for (int i = 0; i < Coordonnees.Count; i++)
            {
                double distance;
                if(i < Coordonnees.Count)
                {
                    distance = MathUtil.DistanceBetweenLine(Coordonnees[i].Longitude, Coordonnees[i].Latitude, Coordonnees[i + 1].Longitude, Coordonnees[i + 1].Latitude, point.Longitude, point.Latitude);
                    if (distance < precision)
                        return true;
                }
                else // derniere ligne pour fermer le polygone
                {
                    distance = MathUtil.DistanceBetweenLine(Coordonnees[i].Longitude, Coordonnees[i].Latitude, Coordonnees[0].Longitude, Coordonnees[0].Latitude, point.Longitude, point.Latitude);
                    if (distance < precision)
                        return true;
                }
            }
            return false;
        }

        #endregion


    }
}
