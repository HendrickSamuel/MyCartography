using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLShape
{
    public class Coordonnees: CartoObj
    {
        #region VARIABLES
        protected double _latitude;
        protected double _longitude;
        #endregion

        #region PROPRIETES
        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value;  }
        }
        #endregion

        #region CONSTRUCTEUR
        public Coordonnees(double latitude, double longitude):base()
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public Coordonnees() : this(0, 0) { }
        #endregion

        #region METHODES
        public override string ToString()
        {
            return base.ToString() + " (" + Latitude.ToString("0.000") + " - " + Longitude.ToString("0.000") + ")";
        }
        #endregion

    }
}
