using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Poco
{
    public class Ref_Reconductible
    {

        public Ref_Reconductible()
        {
            this.Depense = new HashSet<Depense>();
        }

        public int Ref_ReconductibleId { get; set; }
        public string Nom { get; set; }


        public virtual ICollection<Depense> Depense { get; set; }
    }
}
