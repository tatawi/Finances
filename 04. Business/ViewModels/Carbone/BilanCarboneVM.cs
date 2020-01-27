using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Carbone
{
    public class BilanCarboneVM
    {
        public int Annee { get; set; }
        public int Logement { get; set; }
        public int Transports { get; set; }
        public int Alimentation { get; set; }
        public int Dechets { get; set; }
        public int Achats { get; set; }
        public int Finance { get; set; }
        public int ServicePublique { get; set; }
        public int Total { get; set; }

    }
}
