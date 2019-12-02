using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Consommation
{
    public class ConsommationEauAnnuelleVM
    {

        public int Annee { get; set; }
        public decimal MontantCuisineChaud { get; set; }
        public decimal ConsoCuisineChaud { get; set; }
        public decimal MontantCuisineFroid { get; set; }
        public decimal ConsoCuisineFroid { get; set; }
        public decimal MontantSdbChaud { get; set; }
        public decimal ConsoSdbChaud { get; set; }
        public decimal MontantSdbFroid { get; set; }
        public decimal ConsoSdbFroid { get; set; }
        public decimal MontantWcFroid { get; set; }
        public decimal ConsoWcFroid { get; set; }

        public decimal MontantTOTAL { get; set; }
        public decimal ConsoTOTAL { get; set; }

    }


}

