using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finance.Poco
{
    public class InfoAppartement
    {
        public InfoAppartement() { }
        public InfoAppartement(decimal montant, string type, string description, DateTime da)
        {
            this.Montant = montant;
            this.Type = type;
            this.Description = description;
            this.Date = da;
        }

        public int InfoAppartementId { get; set; }
        public Nullable<decimal> Montant { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

    }
}