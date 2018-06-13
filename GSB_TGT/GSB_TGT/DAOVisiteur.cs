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

        public static List<Visiteur> listeVisiteurs()
        {
            List<Visiteur> lesVisiteurs = new List<Visiteur>();
            try
            {
                
                String req = "Select id, nom, prenom, adresse, cp, ville, dateEmbauche, visiteur_medical.idSecteur, nomSecteur From visiteur_medical INNER JOIN secteur ON visiteur_medical.idSecteur = secteur.idSecteur";
                SqlDataReader dr;
                DAOFactory db = new DAOFactory();
                db.connexion();
                dr = db.execSQLread(req);
                while (dr.Read())
                {
                    Secteur secteur = new Secteur(Int32.Parse(dr[7].ToString()), dr[8].ToString());
                    Visiteur vis = new Visiteur(Int32.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), secteur);
                    lesVisiteurs.Add(vis);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERREUR : " + ex);
            }
            return lesVisiteurs;
        }

        public static List<Visiteur> listeRechercheVisiteurs(string text)
        {
            List<Visiteur> lesRecherchesVisiteurs = new List<Visiteur>();
            try
            {

                String req = "Select id, nom, prenom, adresse, cp, ville, dateEmbauche, visiteur_medical.idSecteur, nomSecteur From visiteur_medical INNER JOIN secteur ON visiteur_medical.idSecteur = secteur.idSecteur where nom Like '%" + text + "%' OR prenom Like '%" + text + "%'OR adresse Like '%" + text + "%' OR ville Like '%" + text + "%'OR cp Like '%" + text + "%' OR dateEmbauche Like '%" + text + "%' OR nomSecteur Like '%" + text + "%' ;";
                SqlDataReader dr;
                DAOFactory db = new DAOFactory();
                db.connexion();
                dr = db.execSQLread(req);
                while (dr.Read())
                {
                    Secteur secteur = new Secteur(Int32.Parse(dr[7].ToString()), dr[8].ToString());
                    Visiteur vis = new Visiteur(Int32.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), secteur);
                    lesRecherchesVisiteurs.Add(vis);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERREUR : " + ex);
            }
            return lesRecherchesVisiteurs;
        }

        public static void creerVisiteur(Visiteur visiteur)
        {
            try
            {
                String req = "INSERT INTO visiteur_medical (nom, prenom, adresse, cp, ville, dateEmbauche, idSecteur)  Values ('" + visiteur.Nom + "', '" + visiteur.Prenom
                    + "','" + visiteur.Adresse + "','" + visiteur.Cp + "','" + visiteur.Ville + "','" + visiteur.DateEmbauche + "', " + visiteur.IdSecteur + ")";
                DAOFactory db = new DAOFactory();
                db.connexion();
                db.execSQLwrite(req);
                db.deconnexion();
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
                String req = "UPDATE visiteur_medical SET nom = '" + visiteur.Nom + "', prenom = '" + visiteur.Prenom
                    + "', adresse = '" + visiteur.Adresse + "', cp = '" + visiteur.Cp + "', ville = '" + visiteur.Ville + "', dateEmbauche = '" + visiteur.DateEmbauche + "', idSecteur = " + visiteur.IdSecteur + " WHERE id =" + visiteur.Id +";";
                DAOFactory db = new DAOFactory();
                db.connexion();
                db.execSQLwrite(req);
                db.deconnexion();
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
                String req = "Delete FROM visiteur_medical WHERE id =" + visiteur.Id + ";";
                DAOFactory db = new DAOFactory();
                db.connexion();
                db.execSQLwrite(req);
                db.deconnexion();
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
