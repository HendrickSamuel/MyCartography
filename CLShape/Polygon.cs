using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CLShape
{
    public class Polygon: CartoObj
    {
        #region VARIABLES
        private List<Coordonnees> _coordonnees;
        private Color _contour;
        private Color _remplissage;
        private double _opacite;
        #endregion

        #region PROPRIETES
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
        #endregion

        #region CONSTRUCTEURS
        public Polygon(List<Coordonnees> coordonnees, double opacite, Color contour, Color remplissage):base()
        {
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

            return base.ToString() + " Opacite: " + Opacite +"\n\tFond: "+Remplissage.ToString() + " Contour: "+Contour.ToString() +"\n\tCoordonees: " + stringReturn;
        }

        public override void Draw()
        {
            Console.WriteLine(this.ToString());
        }

        #endregion


    }
}
