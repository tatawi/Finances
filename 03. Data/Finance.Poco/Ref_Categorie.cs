using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Poco
{
    public class Ref_Categorie
    {
        public int Ref_CategorieId { get; set; }
        public string Nom { get; set; }
        public Nullable<decimal> MontantTVA { get; set; }
        public Nullable<int> rang { get; set; }
    }
}
