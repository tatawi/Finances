using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Poco
{
    public class ConsoEau
    {
        public ConsoEau()
        {

        }


        public int ConsoEauId { get; set; }
        public int Annee { get; set; }
        public string Type { get; set; } //Froid / Chaud
        public string Emplacement { get; set; } //sdb / cuisine / wc
        public Nullable<decimal> Conso { get; set; }
        public Nullable<decimal> Montant { get; set; }
    }
}
