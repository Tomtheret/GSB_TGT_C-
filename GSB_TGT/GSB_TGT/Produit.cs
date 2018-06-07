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
		private string Nom_commercial;
		private string Effet_therapeutique;
		private string Contre_indication;
		private string Presentation;
		private string Dosage;
		private float pxHT;
		private float pxEchantillon;
		private int Num_famille;

		public Produit(int unid_produit, string unNom_commercial, string unEffet_therapeutique, string uneContre_indication,
			string unePresentation, string unDosage, float unpxHT, float unpxEchantillon, int unNum_famille)
		{
			Id_produit = unid_produit;
			Nom_commercial1 = unNom_commercial;
			Effet_therapeutique1 = unEffet_therapeutique;
			Contre_indication = uneContre_indication;
			Presentation = unePresentation;
			Dosage = unDosage;
			pxHT = unpxHT;
			PxEchantillon = unpxEchantillon;
			Num_famille = unNum_famille;
		}

		public int Id_produit { get => id_produit; set => id_produit = value; }
		public string Nom_commercial1 { get => Nom_commercial; set => Nom_commercial = value; }
		public string Effet_therapeutique1 { get => Effet_therapeutique; set => Effet_therapeutique = value; }
		public string Contre_indication1 { get => Contre_indication; set => Contre_indication = value; }
		public string Presentation1 { get => Presentation; set => Presentation = value; }
		public string Dosage1 { get => Dosage; set => Dosage = value; }
		public float PxHT { get => pxHT; set => pxHT = value; }
		public float PxEchantillon { get => pxEchantillon; set => pxEchantillon = value; }
		public int Num_famille1 { get => Num_famille; set => Num_famille = value; }



		public static Produit getProduitwithID(int id)
		{
			int i = 0;
			while (i< lesProduits.Count)
			{
				if (lesProduits.ElementAt(i).id_produit == id)
				{
					Cible = lesProduits.ElementAt(i);
				}
				i++;
			}
		}
	}

}
