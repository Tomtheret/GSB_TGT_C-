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
        public static List<Praticien> listePraticien()
        {
            string Req = "select P.Code, P.Raison_sociale, P.Adresse, P.Telephone, P.Contact, P.Coef_notoriete, P.coef_confiance, S.nomSpecialite FROM praticien AS P INNER JOIN specialite AS S on S.idSpecialite=P.idSpecialite;";
            List<Praticien> lesPraticiens = new List<Praticien>();

            try
            {
                SqlDataReader dr;
                DAOFactory db = new DAOFactory();
                db.connexion();
                dr = db.execSQLread(Req);
                while (dr.Read())
                {
                    Praticien pr = new Praticien(dr.GetInt32(0), dr.GetValue(1).ToString(), dr.GetValue(2).ToString(), dr.GetValue(3).ToString(), dr.GetValue(4).ToString(), dr.GetFloat(5), dr.GetFloat(6), dr.GetInt32(7));
                    lesPraticiens.Add(pr);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return lesPraticiens;
        }


        public void addPraticien(Praticien praticien)
        {
            try
            {
                String req = "INSERT INTO praticien (Contact, Telephone, Raison_sociale, Adresse, Coef_notoriete, coef_confiance, idSpecialite) VALUES(" + praticien.Code + "," + praticien.Telephone + "," + praticien.Raison_sociale + "," + praticien.Adresse + "," + praticien.Coef_notoriete + "," + praticien.Coef_confiance + "," + praticien.IdSpecialite +");";
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

        public static void updtPraticien(Praticien praticien)
        {
            try
            {
                String req = "UPDATE praticien SET Raison_sociale = " + praticien.Raison_sociale + ", Adresse = " + praticien.Adresse + ", Telephone = " + praticien.Telephone + ", Contact = '$Contact', Coef_notoriete = " + praticien.Coef_notoriete + ", Coef_confiance = " + praticien.Coef_confiance + ", idSpecialite = " + praticien.IdSpecialite + " WHERE Code = " + praticien.Code + ";";
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

        public static void delPraticien(Praticien praticien)
        {
            try
            {
                String req = "Delete FROM Praticien WHERE code =" + praticien.Code;
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

        public static List<Specialite> getSpecialitePraticien()
        {
            List<Specialite> Specialite = new List<Specialite>();
            try
            {
                String req = "Select * from Specialite";
                SqlDataReader rs;
                DAOFactory db = new DAOFactory();
                db.connexion();
                rs = db.execSQLread(req);
                while (rs.Read())
                {
                    Specialite.Add(new Specialite(Convert.ToInt32(rs[0].ToString()), rs[1].ToString()));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR : " + e);
            }
            return Specialite;
        }
    }
}

