using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Poco
{
    public class BilanCarbone
    {
        
        public int BilanCarboneId { get; set; }
        public int Annee { get; set; }
        public decimal Logement { get; set; }
        public decimal Transports { get; set; }
        public decimal Alimentation { get; set; }
        public decimal Dechets { get; set; }
        public decimal Achats { get; set; }
        public decimal Finance { get; set; }
        public decimal ServicePublique { get; set; }
        public decimal Total { get; set; }

    }
}
