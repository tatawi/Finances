using Finance.Data.bdd;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Managers
{
    public class ConsoEauManager
    {
        private bdd_ConsoEau _bddConsoEau { get; set; }

        public ConsoEauManager()
        {
            _bddConsoEau = new bdd_ConsoEau();
        }



        //Retourne les consommations d'eau pour une année
        public List<ConsoEau> GetAllConsoEauForYear(int annee)
        {
            return _bddConsoEau.get_ListConsoEauForYear(annee);
        }

        //Retourne les consommations d'eau pour une année
        public List<ConsoEau> GetAllConsoEau()
        {
            return _bddConsoEau.get_AllListConsoEau();
        }



        //Ajout d'une consommation d'eau
        public bool AjouterConsommation(ConsoEau conso)
        {
            try
            {
                if (_bddConsoEau.IsConsoPresente(conso))
                    _bddConsoEau.Maj_ConsoEau(conso);
                else
                    _bddConsoEau.Add_ConsoEau(conso);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }


    }
}
