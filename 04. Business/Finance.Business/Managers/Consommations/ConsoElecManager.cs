using Finance.Data.bdd;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Managers
{
    public class ConsoElecManager
    {
        private bdd_Electricite _bddConsoElec { get; set; }

        public ConsoElecManager()
        {
            this._bddConsoElec = new bdd_Electricite();
        }


        //Retourne toutes les consommations d'électricité
        public List<Electricite> GetAllElectricite(string user)
        {
            _bddConsoElec.setUser(user);
            return _bddConsoElec.get_All();
        }

        //Retourne les consommations d'électricité d'une année
        public List<Electricite> GetAllElectriciteForYear(int annee, string user)
        {
            _bddConsoElec.setUser(user);
            return _bddConsoElec.get_ElectriciteForYear(annee);
        }

        //Ajoute une consommation d'électricité
        public bool AjouterConsommation(Electricite conso, string user)
        {
            _bddConsoElec.setUser(user);

            try
            {
                if (_bddConsoElec.IsElectricitePresente(conso))
                    _bddConsoElec.Maj_Electricite(conso);
                else
                    _bddConsoElec.Add_Electricite(conso);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

            
        }






    }
}
