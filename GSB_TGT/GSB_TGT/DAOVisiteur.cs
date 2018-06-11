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
                String req = "Select * from SecteurVisiteur";
                SqlDataReader rs;
                DAOFactory db = new DAOFactory();
                db.connexion();
                rs = db.execSQLread(req);
                while (rs.Read())
                {
                    Localisation.Add(new Secteur(Convert.ToInt32(rs[0].ToString()), rs[1].ToString()));
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
                String req = "Select id, nom, prenom, adresse, cp, ville, dateEmbauche, nomSecteur From Visiteur INNER JOIN Secteur ON Visiteur.idSecteur = Secteur.idSecteur";
                SqlDataReader rs;
                DAOFactory db = new DAOFactory();
                db.connexion();
                rs = db.execSQLread(req);
                Visiteur vis = null;
                while (rs.Read())
                {
                    Secteur secteur = new Secteur(Int32.Parse(rs[7].ToString()), rs[8].ToString());
                    vis = new Visiteur(Int32.Parse(rs[0].ToString()), rs[1].ToString(), rs[2].ToString(), rs[3].ToString(), rs[4].ToString(), rs[5].ToString(), rs[6].ToString(), secteur);
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
                    + "','" + visiteur.Adresse + "','" + visiteur.Cp + "','" + visiteur.Ville + "','" + visiteur.DateEmbauche + "', '" + visiteur.SecteurVisiteur.NumSecteur + "')";
                SqlDataReader rs;
                DAOFactory db = new DAOFactory();
                db.connexion();
                rs = db.execSQLread(req);
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
                String req = "UPDATE Visiteur SET nomVisiteur = '" + visiteur.Nom + "', prenomVisiteur = '" + visiteur.Prenom
                    + "', adresse = '" + visiteur.Adresse + "', cpVisiteur = '" + visiteur.Cp + "', villeVisiteur = '" + visiteur.Ville + "', dateEmbauche = '" + visiteur.DateEmbauche + "', numSecteur = '" + (visiteur.SecteurVisiteur).NumSecteur + "'"
                    + " WHERE numVisiteur =" + visiteur.Id;
                SqlDataReader rs;
                DAOFactory db = new DAOFactory();
                db.connexion();
                rs = db.execSQLread(req);
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
                SqlDataReader rs;
                DAOFactory db = new DAOFactory();
                db.connexion();
                rs = db.execSQLread(req);
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
                SqlDataReader rs;
                DAOFactory db = new DAOFactory();
                db.connexion();
                rs = db.execSQLread(req);
                while (rs.Read())
                {
                    Localisation.Add(new Secteur(Convert.ToInt32(rs[0].ToString()), rs[1].ToString()));
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
