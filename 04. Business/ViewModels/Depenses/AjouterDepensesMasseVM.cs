using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Depenses
{
    public class AjouterDepensesMasseVM
    {
        public AjouterDepensesMasseVM()
        {

        }

        public string user { get; set; }

        public bool compte { get; set; }


        public string donneesImport { get; set; }

        public string message { get; set; }

        public List<Depense> list_Depense { get; set; }
        public List<Depense> list_DepenseAjoutees { get; set; }
    }
}
