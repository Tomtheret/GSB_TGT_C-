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
				String req = "select * FROM interaction;";
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
				String req = "DELETE from interragir WHERE Id_produit='"+interac1+"' AND Id_produit_Medicament='"+interac2+"'";
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
