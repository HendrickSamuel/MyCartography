using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLMathUtil;

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

        public override bool IsPointClose(Coordonnees point, double precision)
        {
            if(precision < 0)
                throw new ArgumentException(String.Format("la precision: {0} est plus petit que zero", precision),"precision");

            double distance = MathUtil.DistanceBetween(Longitude, Latitude, point.Longitude, point.Latitude);
            if (distance < precision)
                return true;
            else
                return false;
        }

        
        public bool IsPointClose(double x, double y, double precision)
        {
            return this.IsPointClose(new Coordonnees(x, y), precision);
        }
        #endregion

    }
    
}
