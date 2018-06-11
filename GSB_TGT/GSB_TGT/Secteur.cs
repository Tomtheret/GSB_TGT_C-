using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_TGT
{
    class Secteur
    {
        private int idSecteur;
        private string nomSecteur;

        public Secteur(int unIdSecteur, string unNomSecteur )
        {
            idSecteur = unIdSecteur;
            nomSecteur = unNomSecteur;
        }

        #region accesseurs
        public int IdSecteur
        {
            get
            {
                return idSecteur;
            }

            set
            {
                idSecteur = value;
            }
        }

        public string NomSecteur
        {
            get
            {
                return nomSecteur;
            }

            set
            {
                nomSecteur = value;
            }
        }
        #endregion

        public static Secteur getSecteurByID(int id)
        {
            List<Secteur> lesSecteurs = DAOSecteur.Secteurs();
            int i = 0;
            bool found = false;
            while (!found && i < lesSecteurs.Count)
            {
                found = (lesSecteurs.ElementAt(i).idSecteur == id);
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
