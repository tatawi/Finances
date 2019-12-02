using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Epargne
{
    public class MontantsComptesVM
    {
        public List<ValCompte> ListeComptes { get; set; }

        public DateTime Date { get; set; }


    }

    public class ValCompte
    {
        public int CompteId { get; set; }
        public int Montant { get; set; }
        public int Ident { get; set; }

    }
}
