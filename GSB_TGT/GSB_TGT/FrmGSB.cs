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
		private List<Interaction> listInteraction;

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

		private void dgvInteraction_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			int rowIndex = e.RowIndex;
			DataGridViewRow row = dgvInteraction.Rows[rowIndex];
			DAOInteractions.supprInteraction(Int32.Parse(row.Cells[0].Value.ToString()), Int32.Parse(row.Cells[0].Value.ToString()));
		}

			private void dgvMedicaments_SelectionChanged(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dgvMedicaments.SelectedRows)
			{
				txbProNum.Text = row.Cells[0].Value.ToString();
				txbProNom.Text = row.Cells[1].Value.ToString();
				txbProEffet.Text = row.Cells[2].Value.ToString();
				txbProContreInd.Text = row.Cells[3].Value.ToString();
				txbProPresentation.Text = row.Cells[4].Value.ToString();
				txbProDosage.Text = row.Cells[5].Value.ToString();
				txbProPrix.Text = row.Cells[6].Value.ToString();
				txbProPrixEchantillon.Text = row.Cells[7].Value.ToString();
				cbxProFamille.Text = row.Cells[8].Value.ToString();


			}
		}

		private void tabVisiteur_Click(object sender, EventArgs e)
        {

        }

        private void FrmGSB_Load_1(object sender, EventArgs e)
        {
			actualiserProduit();
			listfamille = DAOFamilleMedoc.listeFamilles();
			cbxProFamille.DataSource = null;
			foreach (FamilleMedoc listfamill in listfamille)
			{
				cbxProFamille.Items.Add(listfamill.NomFamille);
			}

			listInteraction = DAOInteractions.listeInteractions();
			cbxProAssociation1.DataSource = null;
			cbxProAssociation2.DataSource = null;
			foreach (Interaction uneInteraction in listInteraction)
			{
				cbxProAssociation1.Items.Add(uneInteraction.Interaction1);
				cbxProAssociation2.Items.Add(uneInteraction.Interaction2);
			}
		}

        private void btnProAjouter_Click(object sender, EventArgs e)
        {
            Produit p = new Produit(Int32.Parse(txbProNum.Text), txbProNom.Text, txbProEffet.Text, txbProContreInd.Text, txbProPresentation.Text, txbProDosage.Text, float.Parse(txbProPrix.Text), float.Parse(txbProPrixEchantillon.Text) , DAOFamilleMedoc.getIdFamilleFromNomFamille(cbxProFamille.Text));
            /*string requete = "insert into medicament values(" + txbProNum.Text + "," + txbProNom.Text + ","+ txbProEffet.Text +","
                + txbProContreInd.Text + ","+ txbProPresentation.Text+","+ txbProDosage.Text + "," + txbProPrix.Text + "," +txbProPrixEchantillon.Text +"," + cbxProFamille.Text +"); ";*/
            DAOProduit.setProduit(p);
        }

        private void txbProPrixEchantillon_TextChanged(object sender, EventArgs e)
        {

        }

		private void actualiserProduit()
		{
			listMedoc = DAOProduit.listeProduit();
			dgvMedicaments.DataSource = null;
			dgvMedicaments.DataSource = listMedoc;

			listInteraction = DAOInteractions.listeInteractions();
			dgvInteraction.DataSource = null;
			dgvInteraction.DataSource = listInteraction;


			
		}

		private void btnProModifier_Click(object sender, EventArgs e)
		{
			Produit p = new Produit(Int32.Parse(txbProNum.Text), txbProNom.Text, txbProEffet.Text, txbProContreInd.Text, txbProPresentation.Text, txbProDosage.Text, float.Parse(txbProPrix.Text), float.Parse(txbProPrixEchantillon.Text), DAOFamilleMedoc.getIdFamilleFromNomFamille(cbxProFamille.Text));
			DAOProduit.updateProduit(p);
		}

		private void btnProSupprimer_Click(object sender, EventArgs e)
		{
			Produit p = new Produit(Int32.Parse(txbProNum.Text), txbProNom.Text, txbProEffet.Text, txbProContreInd.Text, txbProPresentation.Text, txbProDosage.Text, float.Parse(txbProPrix.Text), float.Parse(txbProPrixEchantillon.Text), DAOFamilleMedoc.getIdFamilleFromNomFamille(cbxProFamille.Text));
			DAOProduit.supprProduit(p);
		}
	}
}
