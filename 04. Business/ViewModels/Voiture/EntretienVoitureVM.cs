using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Voiture
{
    public class EntretienVoitureVM
    {
        public int EntretienVoitureId { get; set; }
        public DateTime? Date { get; set; }
        public int? Annee { get; set; }
        public string DateStr { get; set; }
        public int Km { get; set; }
        public int Cout { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool Effectue { get; set; }
    }
}
