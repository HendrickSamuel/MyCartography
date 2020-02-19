using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLShape
{
    public class BoundingBox: IComparable<BoundingBox>
    {
        #region VARIABLES
        private Coordonnees _min;
        private Coordonnees _max;
        #endregion

        #region PROPRIETES
        public Coordonnees Min
        {
            get { return _min; }
            set { _min = value; }
        }
        public Coordonnees Max
        {
            get { return _max; }
            set { _max = value; }
        }

        #endregion

        #region CONSTRUCTEURS
        public BoundingBox(Coordonnees c1, Coordonnees c2)
        {
            if (c1 != null)
                Min = c1;
            else
                Min = new Coordonnees();

            if (c2 != null)
                Max = c2;
            else
                Max = new Coordonnees();
        }

        public BoundingBox():this(new Coordonnees(0,0), new Coordonnees(0,0)){}
        #endregion

        #region METHODES
        public void InitBbox(List<Coordonnees> l)
        {
            if (l.Count == 0)
                return;
     
            double bBx1 = l[0].Latitude, bBy1 = l[0].Longitude;
            double bBx2 = l[0].Latitude, bBy2 = l[0].Longitude;
            // calculer la bounding box
            foreach (Coordonnees c in l)
            {
                if (c.Latitude < bBx1)
                    bBx1 = c.Latitude;

                if (c.Latitude > bBx2)
                    bBx2 = c.Latitude;

                if (c.Longitude < bBy1)
                    bBy1 = c.Longitude;

                bBy2 = c.Longitude;
            }

            Min = new Coordonnees(bBx1, bBy1);
            Max = new Coordonnees(bBx2, bBy2);
        }

        public double CalculAir()
        {
            double air;
            air = (Max.Longitude - Min.Longitude) * (Max.Latitude - Min.Latitude); 
            return air;
        }

        public int CompareTo(BoundingBox other)
        {
            return this.CalculAir().CompareTo(other.CalculAir());
        }
        #endregion
    }
}
