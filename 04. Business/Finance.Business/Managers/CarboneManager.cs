using Finance.Data.bdd;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Managers
{
    public class CarboneManager
    {

        private bdd_BilanCarbone _bddBilanCarbone { get; set; }

        public CarboneManager()
        {
            this._bddBilanCarbone = new bdd_BilanCarbone();
        }

        //Retourne les consommations d'eau pour une année
        public BilanCarbone GetBilanCarboneAnnee(int annee, string user)
        {
            _bddBilanCarbone.SetUser(user);
            return _bddBilanCarbone.Get_BilanCarboneForYear(annee);
        }


        //Retourne les consommations d'eau pour une année
        public List<BilanCarbone> GetAllBilanCarbone(string user)
        {
            _bddBilanCarbone.SetUser(user);
            return _bddBilanCarbone.Get_All();
        }


        //Ajout d'une consommation d'eau
        public bool AjouterBilanCarbone(BilanCarbone conso, string user)
        {
            _bddBilanCarbone.SetUser(user);
            try
            {
                if (_bddBilanCarbone.IsBilanCarbonePresent(conso))
                    _bddBilanCarbone.Maj_BilanCarbone(conso);
                else
                    _bddBilanCarbone.Add_BilanCarbone(conso);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
