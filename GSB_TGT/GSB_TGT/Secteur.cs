using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_TGT
{
    class Secteur
    {
        private int numSecteur;
        private string libelleSecteur;

        public int NumSecteur
        {
            get
            {
                return numSecteur;
            }

            set
            {
                numSecteur = value;
            }
        }

        public string LibelleSecteur
        {
            get
            {
                return libelleSecteur;
            }

            set
            {
                libelleSecteur = value;
            }
        }

        public static Secteur getSecteurByID(int num)
        {
            List<Secteur> lesSecteurs = DAOSecteur.Secteurs();
            int i = 0;
            bool found = false;
            while (!found && i < lesSecteurs.Count)
            {
                found = (lesSecteurs.ElementAt(i).NumSecteur == num);
                if (!found)
                {
                    i++;
                }
            }
            if (found)
            {
                return lesSecteurs.ElementAt(i);
            }
            else
            {
                return null;
            }
        }

    }
}
