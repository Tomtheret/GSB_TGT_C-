using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;

namespace GSB_TGT
{
    class DAOProduit
    {
        public static List<Produit> listeProduit()
        {
            string Req = "select M.id_produit,M.Nom_commercial,M.Effet_therapeutique,M.Contre_indication,M.Presentation,M.Dosage,M.pxHT,M.pxEchantillon,F.nomFamille FROM medicament AS M INNER JOIN famille AS F on M.idFamille=F.idFamille order by M.id_produit;";
            List<Produit> lesProduits = new List<Produit>();
            List<FamilleMedoc> lesMedocs = new List<FamilleMedoc>();
            Dictionary<Produit, Produit> lesInteractions = new Dictionary<Produit, Produit>();
            try
            {
                SqlDataReader dr;
                DAOFactory db = new DAOFactory();
                db.connexion();
                dr = db.execSQLread(Req);

                //int i = 1;
                while (dr.Read())
                {
                    //MessageBox.Show("passer " + i + " fois");
                    //i++;
                    //for (int k = 0; k < 9; k++)
                      //  MessageBox.Show(dr.GetValue(k).ToString());

                    /*NumberFormatInfo current1 = CultureInfo.CurrentCulture.NumberFormat;
                    current1.NumberDecimalSeparator = ",";*/

                    //Produit p = new Produit(dr.GetInt32(0), dr.GetString(1), dr.GetValue(2).ToString(), dr.GetValue(3).ToString(), dr.GetValue(4).ToString(), dr.GetValue(5).ToString(), dr.GetFloat(6), dr.GetFloat(7), dr.GetInt32(8));
                    //Produit p = new Produit(dr.GetInt32(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetFloat(6), dr.GetFloat(7), dr.GetInt32(8));
                    Produit p = new Produit(int.Parse(dr[0].ToString()), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), float.Parse(dr[6].ToString()), float.Parse(dr[7].ToString()), DAOFamilleMedoc.getIdFamilleFromNomFamille(dr[8].ToString()));
                    lesProduits.Add(p);
                }
                db.deconnexion();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            /*if (!lesProduits.Any())
            {
                MessageBox.Show("vide");
            }
            else
            {
                MessageBox.Show("pas vide");
            }*/
            return lesProduits;
        }

        public static void setProduit(Produit p)
        {
            string requete = "insert into medicament values(" + p.Id_produit + ",'" + p.Nom_commercial + "','" + p.Effet_therapeutique + "','"
                + p.Contre_indication + "','" + p.Presentation + "','" + p.Dosage + "'," + p.PxHT + "," + p.PxEchantillon + "," + p.IdFamille + "); ";
            
            DAOFactory db = new DAOFactory();
            db.connexion();
            db.execSQLwrite(requete);

        }
		public static void updateProduit(Produit p)
		{
			string req = "UPDATE medicament SET Nom_commercial = '"+ p.Nom_commercial + "', Effet_therapeutique = '" + p.Effet_therapeutique + "',Contre_indication = '"
				+ p.Contre_indication + "', Presentation = '" + p.Presentation + "', Dosage = '" + p.Dosage + "', PxHT= '" + p.PxHT + "', pxEchantillon = '" + p.PxEchantillon + "'" +
				", idFamille='" + p.IdFamille + "' WHERE Id_produit='" + p.Id_produit + "' ";
			DAOFactory db = new DAOFactory();
			db.connexion();
			db.execSQLwrite(req);

		}



		public static void supprProduit(Produit p)
		{
			string req1 = "DELETE from interragir WHERE Id_produit='" + p.Id_produit + "' OR Id_produit_Medicament='" + p.Id_produit + "'";
			string req2 = "DELETE from medicament WHERE Id_produit='" + p.Id_produit + "'";
			DAOFactory db = new DAOFactory();
			db.connexion();
			db.execSQLwrite(req1);
			db.execSQLwrite(req2);
		}


	}
}
