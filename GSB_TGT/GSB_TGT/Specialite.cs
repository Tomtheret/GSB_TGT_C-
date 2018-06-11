using System.Collections.Generic;
using System.Linq;

namespace GSB_TGT
{
    public class Specialite
    {
        private int idSpecialite;
        private string nomSpecialite;

        public Specialite(int unIdSpecialite, string unNomSpecialite)
        {
            idSpecialite = unIdSpecialite;
            nomSpecialite = unNomSpecialite;
        }

        #region accesseurs
        public int NumSpecialite
        {
            get
            {
                return idSpecialite;
            }

            set
            {
                idSpecialite = value;
            }
        }

        public string NomSpecialite
        {
            get
            {
                return nomSpecialite;
            }

            set
            {
                nomSpecialite = value;
            }
        }
        #endregion

        public static Specialite getSpecialiteWithID(int num)
        {
            List<Specialite> lesSpecialites = DAOSpecialite.Specialites();
            int i = 0;
            bool found = false;
            while (!found && i < lesSpecialites.Count)
            {
                found = (lesSpecialites.ElementAt(i).NumSpecialite == num);
                if (!found)
                {
                    i++;
                }
            }
            if (found)
            {
                return lesSpecialites.ElementAt(i);
            }
            else
            {
                return null;
            }
        }
    }
}