using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLShape
{
    public abstract class CartoObj:IIsPointClose
    {
        #region
        private static int _compteur = 0;
        #endregion
        #region VARIABLES
        private int _id;

        #endregion

        #region PROPRIETES
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private static int Compteur
        {
            get { return _compteur; }
            set { _compteur = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public CartoObj()
        {
            Compteur++;
            Id = Compteur;
        }
        #endregion

        #region METHODES
        public override string ToString()
        {
            return "id: "+Id+ " ";
        }

        public virtual void Draw()
        {
            Console.WriteLine(this.ToString());
        }

        public virtual bool IsPointClose(Coordonnees coordonnees, double precision)
        {
            return false;
        }

        #endregion
    }
}
