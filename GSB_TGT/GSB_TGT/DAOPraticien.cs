using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSB_TGT
{
    class DAOPraticien
    {
        private static int res;

        public static List<Praticien> listePraticien()
        {
            string Req = "select Code, Raison_sociale, Adresse, Telephone, Contact, Coef_notoriete, coef_confiance, praticien.idSpecialite, nomSpecialite FROM praticien INNER JOIN specialite on praticien.idSpecialite = specialite.idSpecialite ;";
            List<Praticien> lesPraticiens = new List<Praticien>();

            try
            {
                
                SqlDataReader dr;
                DAOFactory db = new DAOFactory();
                db.connexion();
                dr = db.execSQLread(Req);
                while (dr.Read())
                {
                    Specialite specialite = new Specialite (Int32.Parse(dr[7].ToString()), dr[8].ToString());
                    Praticien pra = new Praticien(Int32.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), float.Parse(dr[5].ToString()), float.Parse(dr[6].ToString()), specialite);
                    lesPraticiens.Add(pra);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return lesPraticiens;
        }


        public static void addPraticien(Praticien praticien)
        {
            try
            {
                String req = "INSERT INTO praticien (Contact, Telephone, Raison_sociale, Adresse, Coef_notoriete, coef_confiance, idSpecialite) VALUES('" + praticien.Contact + "','" + praticien.Telephone + "','" + praticien.Raison_sociale + "','" + praticien.Adresse + "'," + praticien.Coef_notoriete + "," + praticien.Coef_confiance + "," + praticien.IdSpecialite +");";
                DAOFactory db = new DAOFactory();
                db.connexion();
                db.execSQLwrite(req);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERREUR : " + ex);
            }
        }

        public static void updtPraticien(Praticien praticien)
        {
            try
            {
                String req = "UPDATE praticien SET Raison_sociale = '" + praticien.Raison_sociale + "', Adresse = '" + praticien.Adresse + "', Telephone = '" + praticien.Telephone + "', Contact = '" + praticien.Contact + "', Coef_notoriete = " + praticien.Coef_notoriete + ", Coef_confiance = " + praticien.Coef_confiance + ", idSpecialite = " + praticien.IdSpecialite + " WHERE Code = " + praticien.Code + ";";
                DAOFactory db = new DAOFactory();
                db.connexion();
                db.execSQLwrite(req);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERREUR : " + ex);
            }

        }

        public static void delPraticien(Praticien praticien)
        {
            try
            {
                String req = "Delete FROM Praticien WHERE code =" + praticien.Code;
                SqlDataReader rs;
                DAOFactory db = new DAOFactory();
                db.connexion();
                db.execSQLwrite(req);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERREUR : " + ex);
            }
        }

        public static int getIdSpecialitePraticien(Specialite nomSpecialite)
        {
            try
            {
                String req = "Select idSpecialite from Praticien WHERE idSpecialite = ( Select idSpecialite from Specialite WHERE nomSpecialite=" +nomSpecialite+ ";";
                SqlDataReader rs;
                DAOFactory db = new DAOFactory();
                db.connexion();
                rs = db.execSQLread(req);
                res = rs.GetInt32(0);
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR : " + e);
            }
            return res;
        }
    }
}

