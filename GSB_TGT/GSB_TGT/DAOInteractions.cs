using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GSB_TGT
{
    class DAOInteractions
    {
        public static List<Interaction> listeInteractions()
        {
            List<Interaction> lesInteractions = new List<Interaction>();
            try
            {
                String req = "select * FROM interragir;";
                SqlDataReader dr;
                DAOFactory db = new DAOFactory();
                db.connexion();
                dr = db.execSQLread(req);
                while (dr.Read())
                {
                    Interaction uneinteraction = new Interaction(dr.GetInt32(0), dr.GetInt32(1));
                    lesInteractions.Add(uneinteraction);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return lesInteractions;


        }
        public static void supprInteraction(int interac1, int interac2)
        {
            try
            {
                String req = "DELETE from interragir WHERE id_produit='" + interac1 + "' AND id_produit_medicament='" + interac2 + "'";
                DAOFactory db = new DAOFactory();
                db.connexion();
                db.execSQLwrite(req);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public static void setInteraction(Interaction i)
        {
            try
            {
                string req = "INSERT INTO interragir (id_produit, id_produit_medicament) VALUES('" + i.Interaction1 + "','" + i.Interaction2 + "')";
                DAOFactory db = new DAOFactory();
                db.connexion();
                db.execSQLwrite(req);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}

