using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GSB_TGT
{
    class DAOVisiteur
    {
        public DAOVisiteur()
        {

        }

        public static List<Visiteur> lesVisiteurs2 = new List<Visiteur>();

        public static List<Secteur> getSecteurVisiteur()
        {
            List<Secteur> Localisation = new List<Secteur>();
            try
            {
                String req = "Select * from secteur";
                SqlDataReader dr;
                DAOFactory db = new DAOFactory();
                db.connexion();
                dr = db.execSQLread(req);
                while (dr.Read())
                {
                    Localisation.Add(new Secteur(Convert.ToInt32(dr[0].ToString()), dr[1].ToString()));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR : " + e);
            }
            return Localisation;
        }

        public static List<Visiteur> lesVisiteurs()
        {
            try
            {
                String req = "Select id, nom, prenom, adresse, cp, ville, dateEmbauche, visiteur_medical.idSecteur, nomSecteur From visiteur_medical INNER JOIN secteur ON visiteur_medical.idSecteur = secteur.idSecteur";
                SqlDataReader dr;
                DAOFactory db = new DAOFactory();
                db.connexion();
                dr = db.execSQLread(req);
                Visiteur vis = null;
                while (dr.Read())
                {
                    Secteur secteur = new Secteur(Int32.Parse(dr[7].ToString()), dr[8].ToString());
                    vis = new Visiteur(Int32.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), secteur);
                    lesVisiteurs2.Add(vis);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERREUR : " + ex);
            }
            return lesVisiteurs2;
        }

        public void creerVisiteur(Visiteur visiteur)
        {
            try
            {
                String req = "INSERT INTO Visiteur (nom, prenom, adresse, cp, ville, dateEmbauche, idSecteur)  Values ('" + visiteur + "', '" + visiteur.Prenom
                    + "','" + visiteur.Adresse + "','" + visiteur.Cp + "','" + visiteur.Ville + "','" + visiteur.DateEmbauche + "', '" + visiteur.SecteurVisiteur.IdSecteur + "')";
                SqlDataReader dr;
                DAOFactory db = new DAOFactory();
                db.connexion();
                dr = db.execSQLread(req);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERREUR : " + ex);
            }
        }

        public static void modifVisiteur(Visiteur visiteur)
        {
            try
            {
                String req = "UPDATE Visiteur SET nom = '" + visiteur.Nom + "', prenom = '" + visiteur.Prenom
                    + "', adresse = '" + visiteur.Adresse + "', cp = '" + visiteur.Cp + "', ville = '" + visiteur.Ville + "', dateEmbauche = '" + visiteur.DateEmbauche + "', idSecteur = '" + (visiteur.SecteurVisiteur).IdSecteur + "'"
                    + " WHERE id =" + visiteur.Id;
                SqlDataReader dr;
                DAOFactory db = new DAOFactory();
                db.connexion();
                dr = db.execSQLread(req);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERREUR : " + ex);
            }

        }

        public static void supprimerVisiteur(Visiteur visiteur)
        {
            try
            {
                String req = "Delete FROM Visiteur WHERE idVisiteur =" + visiteur.Id;
                SqlDataReader dr;
                DAOFactory db = new DAOFactory();
                db.connexion();
                dr = db.execSQLread(req);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERREUR : " + ex);
            }
        }

        public static List<Secteur> getLocalisationVisiteur()
        {
            List<Secteur> Localisation = new List<Secteur>();
            try
            {
                String req = "Select * from SecteurVisiteur";
                SqlDataReader dr;
                DAOFactory db = new DAOFactory();
                db.connexion();
                dr = db.execSQLread(req);
                while (dr.Read())
                {
                    Localisation.Add(new Secteur(Convert.ToInt32(dr[0].ToString()), dr[1].ToString()));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR : " + e);
            }
            return Localisation;
        }
    }
}
