using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finance.Poco
{
    public class Epargne
    {

        public Epargne()
        {

        }

        public int EpargneId { get; set; }
        public int CompteId { get; set; }
        public Ref_Compte Compte { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Montant { get; set; }
    }
}