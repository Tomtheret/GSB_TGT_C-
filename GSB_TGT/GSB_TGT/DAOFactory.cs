using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace GSB_TGT
{
    class DAOFactory
    {
        SqlCommand maCommand;
        SqlDataReader monDR;
        SqlConnection maConnexion;
        SqlDataAdapter monDataAdapter;

        public DAOFactory()
        {
        }
        public void connexion()
        {
            try
            {
                maConnexion = new SqlConnection("Data Source='172.17.21.10';Initial Catalog=SIO2_GSB_TeamA;User ID=SIO2-dev;Password=btssio-slam-2018");
                maConnexion.Open();
            }
            catch (Exception ex) { MessageBox.Show("Erreur : " + ex.Message); }
        }
        public void deconnexion()
        {
            maConnexion.Close();
        }

        // Requete BDD Read
        public SqlDataReader execSQLread(String req)
        {
            try
            {
                maCommand = new SqlCommand();
                maCommand.CommandText = req;
                maCommand.Connection = maConnexion;
                monDataAdapter = new SqlDataAdapter();
                monDataAdapter.SelectCommand = maCommand;
                monDR = maCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
            return monDR;
        }

        // Requete BDD Write
        public void execSQLwrite(String req)
        {
            try
            {
                maCommand = new SqlCommand();
                maCommand.CommandText = req;
                maCommand.Connection = maConnexion;
                /*monDataAdapter = new SqlDataAdapter();
                monDataAdapter.SelectCommand = maCommand;*/
                maCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex);
            }
        }
    }
}
