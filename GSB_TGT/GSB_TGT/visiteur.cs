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
            this.id = idVisiteur;
            this.nom = nomVisiteur;
            this.prenom = prenomVisiteur;
            this.adresse = adresse;
            this.cp = cpVisiteur;
            this.ville = villeVisiteur;
            this.dateEmbauche = dateEmbaucheVisiteur;
            this.secteurVisiteur = secteurVisiteur;
        }

    }
}
