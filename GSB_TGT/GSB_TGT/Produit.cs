using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSB_TGT
{
    class Produit
    {
        public static List<Produit> lesProduits = new List<Produit>();

        private int id_produit;
        private string nom_commercial;
        private string effet_therapeutique;
        private string contre_indication;
        private string presentation;
        private string dosage;
        private float pxHT;
        private float pxEchantillon;
        private int idFamille;

        public int Id_produit
        {
            get
            {
                return id_produit;
            }

            set
            {
                id_produit = value;
            }
        }

        public string Nom_commercial
        {
            get
            {
                return nom_commercial;
            }

            set
            {
                nom_commercial = value;
            }
        }

        public string Effet_therapeutique
        {
            get
            {
                return effet_therapeutique;
            }

            set
            {
                effet_therapeutique = value;
            }
        }

        public string Contre_indication
        {
            get
            {
                return contre_indication;
            }

            set
            {
                contre_indication = value;
            }
        }

        public string Presentation
        {
            get
            {
                return presentation;
            }

            set
            {
                presentation = value;
            }
        }

        public string Dosage
        {
            get
            {
                return dosage;
            }

            set
            {
                dosage = value;
            }
        }

        public float PxHT
        {
            get
            {
                return pxHT;
            }

            set
            {
                pxHT = value;
            }
        }

        public float PxEchantillon
        {
            get
            {
                return pxEchantillon;
            }

            set
            {
                pxEchantillon = value;
            }
        }

        public int IdFamille
        {
            get
            {
                return idFamille;
            }

            set
            {
                idFamille = value;
            }
        }

        public Produit(int unid_produit, string unNom_commercial, string unEffet_therapeutique, string uneContre_indication,
            string unePresentation, string unDosage, float unpxHT, float unpxEchantillon, int unId_famille)
        {
            id_produit = unid_produit;
            nom_commercial = unNom_commercial;
            effet_therapeutique = unEffet_therapeutique;
            contre_indication = uneContre_indication;
            presentation = unePresentation;
            dosage = unDosage;
            pxHT = unpxHT;
            pxEchantillon = unpxEchantillon;
            idFamille = unId_famille;
        }





        public static Produit getProduitwithID(int id)
        {
            int i = 0;
            while (i < lesProduits.Count)
            {
                if (lesProduits.ElementAt(i).id_produit == id)
                {
                    return lesProduits.ElementAt(i);
                }
                i++;
            }
            MessageBox.Show("Produit non répertorié");
            return null;
        }

        public static void setProduit(Produit p)
        {

        }
    }

}