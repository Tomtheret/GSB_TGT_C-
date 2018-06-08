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
    }
}
