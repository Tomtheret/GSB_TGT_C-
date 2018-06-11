using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSB_TGT
{
    class DAOSpecialite
    {
        public static List<Specialite> ListeSpecialites()
        {
            List<Specialite> LesSpecialites = new List<Specialite>();
            try
            {
                String req = "Select * from specialite";
                SqlDataReader rs;
                DAOFactory db = new DAOFactory();
                db.connexion();
                rs = db.execSQLread(req);
                while (rs.Read())
                {
                    LesSpecialites.Add(new Specialite(Convert.ToInt32(rs[0].ToString()), rs[1].ToString()));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR : " + e);
            }
            return LesSpecialites;
        }

        internal static List<Specialite> Specialites()
        {
            throw new NotImplementedException();
        }

        public static int getIdSpecialiteFromNomSpecialite(string nomSpe)
        {
            int res = 0;
            try
            {

                String req = "select idSpecialite from specialite where nomSpecialite ='" + nomSpe + "'";
                SqlDataReader dr;
                DAOFactory db = new DAOFactory();
                db.connexion();
                dr = db.execSQLread(req);
                while (dr.Read())
                {
                    res = dr.GetInt32(0);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return res;
        }
    }
}
