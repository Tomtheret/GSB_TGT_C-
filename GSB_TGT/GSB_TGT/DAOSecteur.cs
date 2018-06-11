using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GSB_TGT
{
    class DAOSecteur
    {
        public static List<Secteur> Secteurs()
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
        }d
    }
}
