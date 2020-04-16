using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Voiture
{
    public class PleinEssenceVM
    {
        public DateTime Date { get; set; }
        public string DateStr { get; set; }
        public int Annee { get; set; }
        public int Mois { get; set; }
        public int Jour { get; set; }
        public int Km { get; set; }
        public int Litres { get; set; }
        public int Prix { get; set; }
        public decimal PrixLitre { get; set; }
        public string PrixLitreStr { get; set; }
        public string Type { get; set; }
        public decimal Conso { get; set; }

    }
}
