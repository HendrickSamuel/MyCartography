using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLShape
{
    public class POI: Coordonnees
    {
        #region VARIABLES
        private string _description;

        #endregion

        #region PROPRIETES
        public string Description 
        {
            get { return _description; }
            set { _description = value; } 
        }

        #endregion
        #region CONSTRUCTEURS
        public POI(string description, double latitude, double longitude): base(latitude, longitude)
        {
            Description = description;
        }

        public POI() : this("HEPL",50.620796, 5.581418) { }
        #endregion

        #region METHODES
        public override string ToString()
        {
            return base.ToString() + " " + Description;
        }
        #endregion

    }
}
