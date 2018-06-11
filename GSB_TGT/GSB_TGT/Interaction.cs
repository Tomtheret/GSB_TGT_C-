using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_TGT
{
    class Interaction
    {
        public static List<Produit> lesProduits = new List<Produit>();

        private int interaction1;
        private int interaction2;

        public int Interaction1
        {
            get
            {
                return interaction1;
            }

            set
            {
                interaction1 = value;
            }
        }

        public int Interaction2
        {
            get
            {
                return interaction2;
            }

            set
            {
                interaction2 = value;
            }
        }

        public Interaction(int uneinteraction1, int uneinteraction2)
        {
            interaction1 = uneinteraction1;
            interaction2 = uneinteraction2;

        }
    }
}
