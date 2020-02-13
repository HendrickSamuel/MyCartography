using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CLShape
{
    public class Polyline : CartoObj, IPointy
    {
        #region VARIABLES
        private List<Coordonnees> _coordonnees;
        private int _epaisseur;
        private Color _couleur;

        #endregion

        #region PROPRIETES
        

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
            get { return _coordonnees.Count() + 1; /* changer pour compter les ids differents */}
        }

        #endregion

        #region CONSTRUCTEURS
        public Polyline(List<Coordonnees> coordonnees, int epaisseur, Color couleur) : base()
            {
                Coordonnees = coordonnees;
                Epaisseur = epaisseur;
                Couleur = couleur;
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
            throw new NotImplementedException();
        }

        #endregion
    }
}
