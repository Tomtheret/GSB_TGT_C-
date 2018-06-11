using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GSB_TGT
{
    class DAOFamilleMedoc
    {
        public static List<FamilleMedoc> listeFamilles()
        {
            List<FamilleMedoc> lesFamilles = new List<FamilleMedoc>();
            try
            {
                String req = "select * FROM famille;";
                SqlDataReader dr;
                DAOFactory db = new DAOFactory();
                db.connexion();
                dr = db.execSQLread(req);
                while (dr.Read())
                {
                    FamilleMedoc uneFamille = new FamilleMedoc(dr.GetInt32(0), dr.GetValue(1).ToString());
                    lesFamilles.Add(uneFamille);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return lesFamilles;


        }
        public static int getIdFamilleFromNomFamille(string nom)
        {
            int res = 0;
            try
            {

                String req = "select idFamille from famille where nomFamille ='" + nom + "'";
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