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
    public partial class FrmGSB : Form
    {
        private List<Produit> listMedoc;
        private List<FamilleMedoc> listfamille;

        public FrmGSB()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPraticiens_Click(object sender, EventArgs e)
        {

        }

        private void FrmGSB_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvInteraction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabVisiteur_Click(object sender, EventArgs e)
        {

        }

        private void FrmGSB_Load_1(object sender, EventArgs e)
        {
            listMedoc = DAOProduit.listeProduit();
            listfamille = DAOFamilleMedoc.listeFamilles();
            dgvMedicaments.DataSource = null;
            dgvMedicaments.DataSource = listMedoc;
        }

        private void btnProAjouter_Click(object sender, EventArgs e)
        {
            string requete = "insert into medicament values(" + txbProNum.Text + "," + txbProNom.Text + ","+ txbProEffet.Text +","
                + txbProContreInd.Text + ","+ txbProPresentation+","+ txbProDosage + "," + txbProPrix.Text + "," +txbProPrixEchantillon.Text +"," + cbxProFamille.Text +"); ";

        }
    }
}
