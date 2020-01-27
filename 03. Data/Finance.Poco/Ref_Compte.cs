using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finance.Poco
{
    public class Ref_Compte
    {


        public Ref_Compte()
        {

        }

        public int Ref_CompteId { get; set; }
        public string Compte { get; set; }
        public int UtilisateurId { get; set; }
        public bool IsActif { get; set; }
        public Nullable<int> Montant { get; set; }
    }
}