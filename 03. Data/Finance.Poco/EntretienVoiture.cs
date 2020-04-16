using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Poco
{
    public class EntretienVoiture
    {
        public int EntretienVoitureId { get; set; }
        public DateTime? Date { get; set; }
        public int Km { get; set; }
        public int Cout { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public bool Effectue { get; set; }
    }
}
