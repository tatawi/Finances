using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Poco
{
    public class PleinEssence
    {
        public int PleinEssenceId { get; set; }
        public DateTime Date { get; set; }
        public int Km { get; set; }
        public int Litres { get; set; }
        public int Prix { get; set; }
        public string Type { get; set; }
        public decimal Conso { get; set; }
        public int UtilisateurId { get; set; }


    }
}
