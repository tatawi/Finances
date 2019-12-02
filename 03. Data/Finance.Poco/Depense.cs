using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Poco
{

    public partial class Depense
    {
        public Depense() { }
        public Depense(decimal montant, string cat, string ssCat, DateTime da)
        {
            this.Montant = montant;
            this.Categorie = cat;
            this.SousCategorie = ssCat;
            this.Libelle = cat + ssCat;
            this.Date = da;
            this.Reconductible = "Non";
        }

        public int DepenseId { get; set; }
        public Nullable<decimal> Montant { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Libelle { get; set; }
        public string Categorie { get; set; }
        public string SousCategorie { get; set; }
        public string Reconductible { get; set; }
    }
}
