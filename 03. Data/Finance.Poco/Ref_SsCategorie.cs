using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Poco
{
    public class Ref_SsCategorie
    {
        public int Ref_SsCategorieId { get; set; }
        public string Nom { get; set; }
        public string Categorie { get; set; }
        public Nullable<int> rang { get; set; }
    }
}
