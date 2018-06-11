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

        public void creerVisiteur(Visiteur visiteur)
        {
            /*try
            {
                String req = "INSERT INTO Visiteur (nom, prenom, adresse, cp, ville, dateEmbauche, idSecteur)  Values ('" + visiteur + "', '" + visiteur.prenomVisiteur
                    + "','" + visiteur.adresse + "','" + visiteur.cp + "','" + visiteur.ville  + "','" + visiteur.dateEmbauche + "', '" + visiteur.SecteurVisiteur.NumSecteur + "')";
                SqlDataReader rs;
                DAOFactory db = new DAOFactory();
                db.connect();
                rs = db.execSQLread(req);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERREUR : " + ex);
            }*/
        }
    }
}
