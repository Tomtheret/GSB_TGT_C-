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

            dgvPraticiens.Rows.Clear();

            for (int i = 0; i < listPraticiens.Count; i++)
            {
                Praticien p = listPraticiens.ElementAt(i);
                Specialite s = p.Spec;
                dgvPraticiens.Rows.Add(p.Code, p.Contact, p.Raison_sociale, p.Adresse, p.Telephone, p.Coef_notoriete, p.Coef_confiance, s.NomSpecialite);
            }
        }
        public void annulerSaisiePraticien()
        {
            txbPraCode.Text = "";
            txbPraContact.Text = "";
            txbPraRaisonSoc.Text = "";
            txbPraAdresse.Text = "";
            txbPraCoeffConf.Text = "";
            txbPraCoeffNot.Text = "";
            txbPraTelephone.Text = "";
            cbxPraSpec.Text = "";
        }
        private void btnPraSupprimer_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez vous supprimer le praticien : " + txbPraContact.Text + " ?", "caption", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Praticien pra = new Praticien(Int32.Parse(txbPraCode.Text), txbPraRaisonSoc.Text, txbPraAdresse.Text, txbPraTelephone.Text, txbPraContact.Text, Int32.Parse(txbPraCoeffConf.Text), Int32.Parse(txbPraCoeffNot.Text), DAOSpecialite.getIdSpecialiteFromNomSpecialite(cbxPraSpec.Text));
                DAOPraticien.delPraticien(pra);
                actualiserPraticien();
            }
            else if (result == DialogResult.No)
            {
                annulerSaisiePraticien();
            }

        }
        private void btnPraModifier_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez vous modifier le praticien : " + txbPraContact.Text + " ?", "caption", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Praticien pra = new Praticien(Int32.Parse(txbPraCode.Text), txbPraRaisonSoc.Text, txbPraAdresse.Text, txbPraTelephone.Text, txbPraContact.Text, Int32.Parse(txbPraCoeffNot.Text), Int32.Parse(txbPraCoeffConf.Text), DAOSpecialite.getIdSpecialiteFromNomSpecialite(cbxPraSpec.Text));
                DAOPraticien.updtPraticien(pra);
                actualiserPraticien();
            }
            else if (result == DialogResult.No)
            {
                annulerSaisiePraticien();
            }
                

        }
        private void btnPraUpdt_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPraticiens.SelectedRows)
            {
                txbPraCode.Text = row.Cells[0].Value.ToString();
                txbPraContact.Text = row.Cells[1].Value.ToString();
                txbPraRaisonSoc.Text = row.Cells[2].Value.ToString();
                txbPraAdresse.Text = row.Cells[3].Value.ToString();
                txbPraCoeffConf.Text = row.Cells[6].Value.ToString();
                txbPraCoeffNot.Text = row.Cells[5].Value.ToString();
                txbPraTelephone.Text = row.Cells[4].Value.ToString();
                cbxPraSpec.Text = row.Cells[7].Value.ToString();
            }
        }
        private void btnPraAjouter_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez vous ajouter le praticien : " + txbPraContact.Text + " ?", "caption", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Praticien p = new Praticien(txbPraRaisonSoc.Text, txbPraAdresse.Text, txbPraTelephone.Text, txbPraContact.Text, Int32.Parse(txbPraCoeffNot.Text), Int32.Parse(txbPraCoeffConf.Text), DAOSpecialite.getIdSpecialiteFromNomSpecialite(cbxPraSpec.Text));
                DAOPraticien.addPraticien(p);
                actualiserPraticien();
            }
            else if(result == DialogResult.No)
            {
                annulerSaisiePraticien();
            }
                
        }
        private void btnPraAnnuler_Click(object sender, EventArgs e)
        {
            annulerSaisiePraticien();
        }
        private void btnPraRechercher_Click(object sender, EventArgs e)
        {
            listPraticiens = DAOPraticien.ListePraticiensRecherche(txbPraRechercher.Text);

            dgvPraticiens.Rows.Clear();

            for (int i = 0; i < listPraticiens.Count; i++)
            {
                Praticien p = listPraticiens.ElementAt(i);
                Specialite s = p.Spec;
                dgvPraticiens.Rows.Add(p.Code, p.Contact, p.Raison_sociale, p.Adresse, p.Telephone, p.Coef_notoriete, p.Coef_confiance, s.NomSpecialite);
            }
        }
        private void btnPraActualiser_Click(object sender, EventArgs e)
        {
            actualiserPraticien();
            annulerSaisiePraticien();
        }

        #endregion

        #region Visiteurs

        private void actualiserVisiteur()
        {
            listVisiteur = DAOVisiteur.listeVisiteurs();

            dgvVisiteurs.Rows.Clear();

            for (int i = 0; i < listVisiteur.Count ; i++)
            {
                Visiteur v = listVisiteur.ElementAt(i);
                Secteur s = v.SecteurVisiteur;
                dgvVisiteurs.Rows.Add(v.Id, v.Nom,v.Prenom,v.Adresse,v.Ville,v.Cp,v.DateEmbauche,s.NomSecteur);
            }

        }
        private void btnVisUpdt_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvVisiteurs.SelectedRows)
            {
                txbVisId.Text = row.Cells[0].Value.ToString();
                txbVisNom.Text = row.Cells[1].Value.ToString();
                txbVisPrenom.Text = row.Cells[2].Value.ToString();
                txbVisAdresse.Text = row.Cells[3].Value.ToString();
                txbVisVille.Text = row.Cells[4].Value.ToString();
                txbVisCp.Text = row.Cells[5].Value.ToString();
                txbVisDateEmb.Text = row.Cells[6].Value.ToString();
                cbxVisSecteur.Text = row.Cells[7].Value.ToString();
            }

        }
        public void annulerSaisieVisiteur()
        {
            txbVisId.Text = "";
            txbVisNom.Text = "";
            txbVisPrenom.Text = "";
            txbVisAdresse.Text = "";
            txbVisVille.Text = "";
            txbVisCp.Text = "";
            txbVisDateEmb.Text = "";
            cbxVisSecteur.Text = "";
        }
        private void btnVisAnnuler_Click(object sender, EventArgs e)
        {
            annulerSaisieVisiteur();
        }

        private void btnVisModifier_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Voulez vous modifier le Visiteur : " + txbVisNom.Text + " ?", "caption", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Visiteur vis = new Visiteur(Int32.Parse(txbVisId.Text), txbVisNom.Text, txbVisPrenom.Text, txbVisAdresse.Text, txbVisCp.Text, txbVisVille.Text, txbVisDateEmb.Text, DAOSecteur.getIdSecteurFromNomSecteur(cbxVisSecteur.Text));
                DAOVisiteur.modifVisiteur(vis);
                actualiserVisiteur();
            }
            else if (result == DialogResult.No)
            {
                annulerSaisiePraticien();
            }
        }
        private void btnVisAjouter_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Voulez vous ajouter le Visiteur : " + txbVisNom.Text + " ?", "caption", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Visiteur v = new Visiteur(txbVisNom.Text, txbVisPrenom.Text, txbVisAdresse.Text, txbVisCp.Text, txbVisVille.Text, txbVisDateEmb.Text, DAOSecteur.getIdSecteurFromNomSecteur(cbxVisSecteur.Text));
                DAOVisiteur.creerVisiteur(v);
                actualiserVisiteur();
            }
            else if (result == DialogResult.No)
            {
                annulerSaisiePraticien();
            }
        }

        private void btnVisSupprimer_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Voulez vous supprimer le Visiteur : " + txbVisNom.Text + " ?", "caption", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Visiteur v = new Visiteur(Int32.Parse(txbVisId.Text), txbVisNom.Text, txbVisPrenom.Text, txbVisAdresse.Text, txbVisCp.Text, txbVisVille.Text, txbVisDateEmb.Text, DAOSecteur.getIdSecteurFromNomSecteur(cbxVisSecteur.Text));
                DAOVisiteur.supprimerVisiteur(v);
                actualiserVisiteur();
            }
            else if (result == DialogResult.No)
            {
                annulerSaisiePraticien();
            }
        }
        private void btnVisActu_Click(object sender, EventArgs e)
        {
            annulerSaisieVisiteur();
            actualiserVisiteur();
        }

        private void btnVisRechercher_Click(object sender, EventArgs e)
        {
            listVisiteur = DAOVisiteur.listeRechercheVisiteurs(txbVisRechercher.Text);

            dgvVisiteurs.Rows.Clear();

            for (int i = 0; i < listVisiteur.Count; i++)
            {
                Visiteur v = listVisiteur.ElementAt(i);
                Secteur s = v.SecteurVisiteur;
                dgvVisiteurs.Rows.Add(v.Id, v.Nom, v.Prenom, v.Adresse, v.Ville, v.Cp, v.DateEmbauche, s.NomSecteur);
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

            cbxProAssociation1.Items.Clear();
            cbxProAssociation2.Items.Clear();
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

        private void btnProAnnuler_Click(object sender, EventArgs e)
        {
            txbProNum.Text = "";
            txbProNom.Text = "";
            txbProEffet.Text = "";
            txbProContreInd.Text = "";
            txbProPresentation.Text = "";
            txbProDosage.Text = "";
            txbProPrix.Text = "";
            txbProPrixEchantillon.Text = "";
            cbxProFamille.Text = "";
        }

        private void btnProDissocier_Click(object sender, EventArgs e)
        {
            int inter1 = 0;
            int inter2 = 0;

            foreach (DataGridViewRow row in dgvInteraction.SelectedRows)
            {
                inter1 = Int32.Parse(row.Cells[0].Value.ToString());
                inter2 = Int32.Parse(row.Cells[1].Value.ToString());
            }
            DAOInteractions.supprInteraction(inter1, inter2);
            actualiserProduit();
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
                cbxProFamille.Text = DAOFamilleMedoc.getNomFamilleFromIdFamille(Int32.Parse(row.Cells[8].Value.ToString()));
            }
        }







        #endregion

    }
}
