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
            List<Secteur> ZoneGeo = new List<Secteur>();
            try
            {
                String req = "Select * from SecteurVisiteur";
                SqlDataReader rs;
                DAOFactory db = new DAOFactory();
                db.connect();
                rs = db.execSQLread(req);
                while (rs.Read())
                {
                    ZoneGeo.Add(new Secteur(Convert.ToInt32(rs[0].ToString()), rs[1].ToString()));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR : " + e);
            }
            return ZoneGeo;
        }

        public static List<Visiteur> Visiteurs()
        {
            try
            {
                String req = "Select numVisiteur, nomVisiteur,prenomVisiteur,adresse,cpVisiteur,villeVisiteur,dateEmbauche,numSecteur,descriptionSecteur From Visiteur INNER JOIN SecteurVisiteur ON Visiteur.numSecteur = SecteurVisiteur.idSecteur";
                SqlDataReader rs;
                DAOFactory db = new DAOFactory();
                db.connect();
                rs = db.execSQLread(req);
                Visiteur v = null;
                while (rs.Read())
                {
                    Secteur secteur = new Secteur(Int32.Parse(rs[7].ToString()), rs[8].ToString());
                    v = new Visiteur(Int32.Parse(rs[0].ToString()), rs[1].ToString(), rs[2].ToString(), rs[3].ToString(), rs[4].ToString(), rs[5].ToString(), rs[6].ToString(), secteur);
                    lesVisiteurs2.Add(v);
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
                String req = "INSERT INTO Visiteur (nom, prenom, adresse, cp, ville, dateEmbauche, idSecteur)  Values ('" + visiteur + "', '" + visiteur.prenomVisiteur
                    + "','" + visiteur.adresse + "','" + visiteur.cp + "','" + visiteur.ville + "','" + visiteur.dateEmbauche + "', '" + visiteur.SecteurVisiteur.NumSecteur + "')";
                SqlDataReader rs;
                DAOFactory db = new DAOFactory();
                db.connect();
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
                String req = "UPDATE Visiteur SET nomVisiteur = '" + visiteur.NomVisiteur + "', prenomVisiteur = '" + visiteur.PrenomVisiteur
                    + "', adresse = '" + visiteur.Adresse + "', cpVisiteur = '" + visiteur.CpVisiteur + "', villeVisiteur = '" + visiteur.VilleVisiteur + "', dateEmbauche = '" + visiteur.DateEmbauche + "', numSecteur = '" + (visiteur.SecteurVisiteur).NumSecteur + "'"
                    + " WHERE numVisiteur =" + visiteur.NumVisiteur;
                SqlDataReader rs;
                DAOFactory db = new DAOFactory();
                db.connect();
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
                String req = "Delete FROM Visiteur WHERE idVisiteur =" + visiteur.idVisiteur;
                SqlDataReader rs;
                DAOFactory db = new DAOFactory();
                db.connect();
                rs = db.execSQLread(req);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERREUR : " + ex);
            }
        }

        public static List<Secteur> getSecteurVisiteur()
        {
            List<Secteur> Localisation = new List<Secteur>();
            try
            {
                String req = "Select * from SecteurVisiteur";
                SqlDataReader rs;
                DAOFactory db = new DAOFactory();
                db.connect();
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
