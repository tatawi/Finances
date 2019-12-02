using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Consommation
{
    public class ConsommationEnergieAnnuelleVM
    {

        public int Annee { get; set; }
        public decimal ConsoTotale { get; set; }
        public decimal ConsoEau { get; set; }
        public decimal ConsoElec { get; set; }
        public decimal ConsoChauffage { get; set; }

    }
}
