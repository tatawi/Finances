using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ViewModels.Consolidation
{
    public class ConsoMensuelleVM
    {
        public ConsoMensuelleVM()
        {

        }


        public int Annee { get; set; }
        public int Mois { get; set; }
        public List<SelectListItem> list_mois { get; set; }

        public List<string> list_descriptions { get; set; }
        public List<decimal> list_montants { get; set; }
    }
}
