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
        private List<Visiteur> listVisiteur;
        private List<Praticien> listPraticiens;
        private List<Secteur> listSecteur;
        private List<Specialite> listSpecialite;
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
			actualiserProduit();
			listfamille = DAOFamilleMedoc.listeFamilles();
			cbxProFamille.DataSource = null;
			foreach (FamilleMedoc listfamill in listfamille)
			{
				cbxProFamille.Items.Add(listfamill.NomFamille);
			}

            // Visiteurs
            actualiserVisiteur();
            listSecteur = DAOSecteur.Secteurs();
            cbxVisSecteur.DataSource = null;
            foreach (Secteur listSec in listSecteur)
            {
                cbxVisSecteur.Items.Add(listSec.NomSecteur);
            }

            //Praticiens  
            actualiserPraticien();
            listSpecialite = DAOSpecialite.ListeSpecialites();
            cbxPraSpec.DataSource = null;
            foreach (Specialite listSpec in listSpecialite)
            {
                cbxPraSpec.Items.Add(listSpec.NomSpecialite);
            }
        }

        #region Praticiens
        private void actualiserPraticien()
        {
            listPraticiens = DAOPraticien.listePraticien();
            /*dgvPraticiens.DataSource = null;
            dgvPraticiens.DataSource = listPraticiens;*/

            for (int i = 0; i < listPraticiens.Count; i++)
            {
                Praticien p = listPraticiens.ElementAt(i);
                Specialite s = p.Spec;
                dgvPraticiens.Rows.Add(p.Contact, p.Raison_sociale, p.Adresse, p.Telephone, p.Coef_notoriete, p.Coef_confiance,  s.NomSpecialite);
            }
        }
        #endregion

        #region Visiteurs

        private void actualiserVisiteur()
        {
            listVisiteur = DAOVisiteur.lesVisiteurs();
            /*dgvVisiteurs.DataSource = null;
            dgvVisiteurs.DataSource = listVisiteur;*/
           
            for (int i = 0; i < listVisiteur.Count ; i++)
            {
                Visiteur v = listVisiteur.ElementAt(i);
                Secteur s = v.SecteurVisiteur;
                dgvVisiteurs.Rows.Add(v.Nom,v.Prenom,v.Adresse,v.Ville,v.Cp,v.DateEmbauche,s.NomSecteur);
            }

        }

        #endregion

        #region Médicaments

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

        private void btnProAjouter_Click(object sender, EventArgs e)
        {
            Produit p = new Produit(Int32.Parse(txbProNum.Text), txbProNom.Text, txbProEffet.Text, txbProContreInd.Text, txbProPresentation.Text, txbProDosage.Text, float.Parse(txbProPrix.Text), float.Parse(txbProPrixEchantillon.Text) , DAOFamilleMedoc.getIdFamilleFromNomFamille(cbxProFamille.Text));
            /*string requete = "insert into medicament values(" + txbProNum.Text + "," + txbProNom.Text + ","+ txbProEffet.Text +","
                + txbProContreInd.Text + ","+ txbProPresentation.Text+","+ txbProDosage.Text + "," + txbProPrix.Text + "," +txbProPrixEchantillon.Text +"," + cbxProFamille.Text +"); ";*/
            DAOProduit.setProduit(p);
            actualiserProduit();
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

            cbxProAssociation1.DataSource = null;
            cbxProAssociation2.DataSource = null;
            foreach (Produit unProduit in listMedoc)
            {
                cbxProAssociation1.Items.Add(unProduit.Id_produit);
                cbxProAssociation2.Items.Add(unProduit.Id_produit);
            }
            




        }

		private void btnProModifier_Click(object sender, EventArgs e)
		{
			Produit p = new Produit(Int32.Parse(txbProNum.Text), txbProNom.Text, txbProEffet.Text, txbProContreInd.Text, txbProPresentation.Text, txbProDosage.Text, float.Parse(txbProPrix.Text), float.Parse(txbProPrixEchantillon.Text), DAOFamilleMedoc.getIdFamilleFromNomFamille(cbxProFamille.Text));
			DAOProduit.updateProduit(p);
            actualiserProduit();

        }

		private void btnProSupprimer_Click(object sender, EventArgs e)
		{
			Produit p = new Produit(Int32.Parse(txbProNum.Text), txbProNom.Text, txbProEffet.Text, txbProContreInd.Text, txbProPresentation.Text, txbProDosage.Text, float.Parse(txbProPrix.Text), float.Parse(txbProPrixEchantillon.Text), DAOFamilleMedoc.getIdFamilleFromNomFamille(cbxProFamille.Text));
			DAOProduit.supprProduit(p);
            actualiserProduit();

        }

        private void btnProAssocier_Click(object sender, EventArgs e)
        {
            Interaction i = new Interaction(Int32.Parse(cbxProAssociation1.Text), Int32.Parse(cbxProAssociation2.Text));
            DAOInteractions.setInteraction(i);
            actualiserProduit();
        }

        #endregion

        #region boutons
        private void btnPraModifier_Click(object sender, EventArgs e)
        {
           
        }

        private void btnProUpdt_Click(object sender, EventArgs e)
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

        private void btnPraUpdt_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPraticiens.SelectedRows)
            {
                txbPraContact.Text = row.Cells[0].Value.ToString();
                txbPraRaisonSoc.Text = row.Cells[1].Value.ToString();
                txbPraAdresse.Text = row.Cells[2].Value.ToString();
                txbPraCoeffConf.Text = row.Cells[3].Value.ToString();
                txbPraCoeffNot.Text = row.Cells[4].Value.ToString();
                txbPraTelephone.Text = row.Cells[5].Value.ToString();
                cbxPraSpec.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btnVisUpdt_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvVisiteurs.SelectedRows)
            {
                txbVisNom.Text = row.Cells[0].Value.ToString();
                txbVisPrenom.Text = row.Cells[1].Value.ToString();
                txbVisAdresse.Text = row.Cells[2].Value.ToString();
                txbVisVille.Text = row.Cells[3].Value.ToString();
                txbVisCp.Text = row.Cells[4].Value.ToString();
                txbVisDateEmb.Text = row.Cells[5].Value.ToString();
                cbxVisSecteur.Text = row.Cells[6].Value.ToString();
            }

        }
        #endregion
        private void btnPraAjouter_Click(object sender, EventArgs e)
        {
            Praticien p = new Praticien(txbPraRaisonSoc.Text, txbPraAdresse.Text, txbPraTelephone.Text, txbPraContact.Text, float.Parse(txbPraCoeffNot.Text), float.Parse(txbPraCoeffConf.Text), DAOSpecialite.getIdSpecialiteFromNomSpecialite(cbxPraSpec.Text));
            DAOPraticien.addPraticien(p);
            actualiserPraticien();
        }
    }
}
