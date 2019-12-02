using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Consommation
{
    public class ConsommationElecAnnuelle
    {
        public int Annee { get; set; }
        public int Consommation { get; set; }
        public decimal Montant { get; set; }

        public List<ConsommationElecMensuelle> listeConsoMois { get; set; }


        public ConsommationElecAnnuelle()
        {
            this.listeConsoMois = new List<ConsommationElecMensuelle>();
        }

    }
}
