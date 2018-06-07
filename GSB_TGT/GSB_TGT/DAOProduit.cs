using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GSB_TGT
{
    class DAOProduit
    {
		public static List<Produit> listeProduit()
		{
			string Req = "select M.id_produit,M.Nom_commercial,M.Effet_therapeutique,M.Contre_indication,M.Presentation,M.Dosage,M.pxHT,M.pxEchantillon,F.nomFamille FROM medicament AS M INNER JOIN famille AS F on M.idFamille = F.idFamille order by M.id_produit;";
			List<Produit> lesProduits = new List<Produit>();
			Dictionary<Produit,Produit> lesInteractions = new Dictionary<Produit, Produit>();

			try
			{
				SqlDataReader dr;
				DAOFactory db = new DAOFactory();
				db.connect();
				dr = db.execSQLread(Req);
				while (dr.Read())
				{
					Produit p = new Produit(dr.GetInt32(0), dr.GetValue(1).ToString(), dr.GetValue(2).ToString(), dr.GetValue(3).ToString(), dr.GetValue(4).ToString(), dr.GetValue(5).ToString(), dr.GetFloat(6), dr.GetFloat(7), dr.GetInt32(8));
					lesProduits.Add(p);
				}

			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
			return lesProduits;
		}

	}
}
