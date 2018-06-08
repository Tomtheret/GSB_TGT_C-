using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSB_TGT
{
    class Praticien
    {
        public static List<Praticien> lesPraticiens = new List<Praticien>();

        private int code;
        private string raison_sociale;
        private string adresse;
        private string telephone;
        private string contact;
        private float coef_notoriete;
        private float coef_confiance;
        private int idSpecialite;

        public string Raison_sociale
        {
            get
            {
                return raison_sociale;
            }

            set
            {
                raison_sociale = value;
            }
        }

        public int Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public string Adresse
        {
            get
            {
                return adresse;
            }

            set
            {
                adresse = value;
            }
        }

        public string Telephone
        {
            get
            {
                return telephone;
            }

            set
            {
                telephone = value;
            }
        }

        public string Contact
        {
            get
            {
                return contact;
            }

            set
            {
                contact = value;
            }
        }

        public float Coef_notoriete
        {
            get
            {
                return coef_notoriete;
            }

            set
            {
                coef_notoriete = value;
            }
        }

        public float Coef_confiance
        {
            get
            {
                return coef_confiance;
            }

            set
            {
                coef_confiance = value;
            }
        }

        public int IdSpecialite
        {
            get
            {
                return idSpecialite;
            }

            set
            {
                idSpecialite = value;
            }
        }

        public Praticien(int UnCode, string UneRaison_sociale, string UneAdresse,string UnTelephone, string UnContact, float UnCoef_notoriete, float UnCoef_confiance, int UnIdSpecialite)
        {
        code = UnCode;
        raison_sociale = UneRaison_sociale;
        adresse = UneAdresse;
        telephone = UnTelephone;
        contact = UnContact;
        coef_notoriete = UnCoef_notoriete;
        coef_confiance = UnCoef_confiance;
        idSpecialite = UnIdSpecialite;
        }


        public static Praticien getPraticienwithCode(int code)
        {
            int i = 0;
            while (i < lesPraticiens.Count)
            {
                if (lesPraticiens.ElementAt(i).code == code)
                {
                    return lesPraticiens.ElementAt(i);
                }
                i++;
            }
            MessageBox.Show("Praticien non existant");
            return null;
        }
    }
}
