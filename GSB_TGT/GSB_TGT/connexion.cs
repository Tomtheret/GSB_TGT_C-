using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace GSB_TGT
{
    public partial class FrmConnexion : Form
    {

        public FrmConnexion()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source='172.17.21.10';Initial Catalog=SIO2_GSB_TeamA;User ID=SIO2-dev;Password=btssio-slam-2018");
                SqlDataAdapter res = new SqlDataAdapter("Select Count(*) FROM utilisateur where login='" + txbLogin.Text + "' and mdp='" + txbMdp.Text + "'", con);
                DataTable dt = new DataTable();
                res.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    FrmGSB frm = new FrmGSB();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Vous n'êtes pas autorisé à vous connecter");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERREUR : " + ex);
            }

        }
    }
}
