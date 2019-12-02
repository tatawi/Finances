using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Consommation
{
    public class ConsommationElecMensuelle
    {
        public int Annee { get; set; }
        public int Mois { get; set; }
        public string MoisStr { get; set; }
        public int Consommation { get; set; }
        public decimal Montant { get; set; }
    }
}
