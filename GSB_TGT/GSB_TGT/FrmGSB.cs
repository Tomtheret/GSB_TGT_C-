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

            cbxProFamille.DataSource = null;

            foreach (FamilleMedoc listfamill in listfamille)
            {
                cbxProFamille.Items.Add(listfamill.NomFamille);
                cbxProFamille.ValueMember = listfamill.IdFamille.ToString();
            }

        }

        private void btnProAjouter_Click(object sender, EventArgs e)
        {
            Produit p = new Produit(Int32.Parse(txbProNum.Text), txbProNom.Text, txbProEffet.Text, txbProContreInd.Text, txbProPresentation.Text, txbProDosage.Text, float.Parse(txbProPrix.Text), float.Parse(txbProPrixEchantillon.Text) , Int32.Parse(cbxProFamille.ValueMember));
            /*string requete = "insert into medicament values(" + txbProNum.Text + "," + txbProNom.Text + ","+ txbProEffet.Text +","
                + txbProContreInd.Text + ","+ txbProPresentation.Text+","+ txbProDosage.Text + "," + txbProPrix.Text + "," +txbProPrixEchantillon.Text +"," + cbxProFamille.Text +"); ";*/
            DAOProduit.setProduit(p);
        }

        private void txbProPrixEchantillon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
