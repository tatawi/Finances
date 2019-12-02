using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finance.Poco
{
    public class Electricite
    {

        public Electricite() { }
        public Electricite(decimal montant, int Consommation, string description, DateTime da, decimal Prix)
        {
            this.Montant = montant;
            this.Consommation = Consommation;
            this.Description = description;
            this.Date = da;
            this.PrixKwh = Prix;
        }

        public int ElectriciteId { get; set; }
        public Nullable<decimal> Montant { get; set; }
        public Nullable<int> Consommation { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> PrixKwh { get; set; }
    }
}