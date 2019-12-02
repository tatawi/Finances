using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finance.Poco
{
    public class ConsoChauffage
    {


        public ConsoChauffage() { }

        

        public int ConsoChauffageId { get; set; }
        public int Annee { get; set; }
        public int ConsoTotale { get; set; }
        public int ConsoPerso { get; set; }
        public int CoutTotal { get; set; }
        public int CoutPerso { get; set; }
        public int KwhTotal { get; set; }
        public int KwhPerso { get; set; }
        public decimal CoutKwh { get; set; }

    }
}