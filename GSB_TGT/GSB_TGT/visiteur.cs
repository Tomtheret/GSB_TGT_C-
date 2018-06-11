using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_TGT
{
    class Visiteur
    {
        private static DAOVisiteur db = new DAOVisiteur();
        public static List<Visiteur> lesVisiteurs = new List<Visiteur>();
        private int id;
        private string nom;
        private string prenom;
        private string adresse;
        private string cp;
        private string ville;
        private string dateEmbauche;
        private Secteur secteurVisiteur;

        public Visiteur(int idVisiteur, string nomVisiteur, string prenomVisiteur, string adresse, string cpVisiteur, string villeVisiteur, string dateEmbaucheVisiteur, Secteur secteurVisiteur)
        {
            this.Id = idVisiteur;
            this.Nom = nomVisiteur;
            this.Prenom = prenomVisiteur;
            this.Adresse = adresse;
            this.Cp = cpVisiteur;
            this.Ville = villeVisiteur;
            this.DateEmbauche = dateEmbaucheVisiteur;
            this.SecteurVisiteur = secteurVisiteur;
        }

        #region acceseurs 

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                prenom = value;
            }
        }

        public string Adresse
        {
            get
            {
                return adresse;
            }

            set
            {
                adresse = value;
            }
        }

        public string Cp
        {
            get
            {
                return cp;
            }

            set
            {
                cp = value;
            }
        }

        public string Ville
        {
            get
            {
                return ville;
            }

            set
            {
                ville = value;
            }
        }

        public string DateEmbauche
        {
            get
            {
                return dateEmbauche;
            }

            set
            {
                dateEmbauche = value;
            }
        }

        public Secteur SecteurVisiteur
        {
            get
            {
                return secteurVisiteur;
            }

            set
            {
                secteurVisiteur = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }



        #endregion

        public static Visiteur getVisiteurByNom(string nom)
        {
            List<Visiteur> lesVisiteurs = DAOVisiteur.lesVisiteurs();
            int i = 0;
            bool found = false;
            while (!found && i < lesVisiteurs.Count)
            {
                found = (lesVisiteurs.ElementAt(i).nom == nom);
                if (!found)
                {
                    i++;
                }
            }
            if (found)
            {
                return lesVisiteurs.ElementAt(i);
            }
            else
            {
                return null;
            }
        }

        public static Visiteur getVisiteurByNum(int id)
        {
            List<Visiteur> lesVisiteurs = DAOVisiteur.lesVisiteurs();
            int i = 0;
            bool found = false;
            while (!found && i < lesVisiteurs.Count)
            {
                found = (lesVisiteurs.ElementAt(i).Id == id);
                if (!found)
                {
                    i++;
                }
            }
            if (found)
            {
                return lesVisiteurs.ElementAt(i);
            }
            else
            {
                return null;
            }
        }

    }
}
