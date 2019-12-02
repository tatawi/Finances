using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ViewModels.Depenses
{
    public class AjouterDepenseUnitaireVM
    {
        public AjouterDepenseUnitaireVM()
        {

        }

        //Affichage
        public int Annee { get; set; }
        public int Mois { get; set; }
        public List<SelectListItem> list_mois { get; set; }
        public List<Depense> list_Depenses { get; set; }


        //pop-up add
        public decimal Montant { get; set; }
        public string MontantStr { get; set; }
        public DateTime Date { get; set; }
        public string strDate { get; set; }
        public string Libelle { get; set; }
        public string strCategorie { get; set; }
        public string strSousCategorie { get; set; }
        public string strCatOuSsCat { get; set; }
        public string strReconductible { get; set; }
        public int SsCat { get; set; }
        public List<SelectListItem> list_SsCat { get; set; }

        public bool chReconductible { get; set; }

        public string user { get; set; }

        public bool compte { get; set; }
    }

}
