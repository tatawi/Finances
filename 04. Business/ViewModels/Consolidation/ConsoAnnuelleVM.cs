using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Consolidation
{
    public class ConsoAnnuelleVM
    {

        public int Annee { get; set; }
        public List<string> list_descriptions { get; set; }
        public List<decimal> list_montants { get; set; }
    }
}
