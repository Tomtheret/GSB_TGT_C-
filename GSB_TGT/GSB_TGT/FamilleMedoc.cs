using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSB_TGT
{
	class FamilleMedoc
	{
		private int idFamille;
		private string nomFamille;

		public FamilleMedoc(int id, string nom)
		{
			idFamille = id;
			nomFamille = nom;
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

        public string NomFamille
        {
            get
            {
                return nomFamille;
            }

            set
            {
                nomFamille = value;
            }
        }

        public static FamilleMedoc getFamilleById(int id)
		{
			List<FamilleMedoc> lesFamilles = DAOFamilleMedoc.listeFamilles();
			int i = 0;

			while (i < lesFamilles.Count)
			{
				if (lesFamilles.ElementAt(i).idFamille == id)
				{
					return lesFamilles.ElementAt(i);
				}
				i++;
			}
			MessageBox.Show("Produit non répertorié");
			return null;

		}

	}

}
