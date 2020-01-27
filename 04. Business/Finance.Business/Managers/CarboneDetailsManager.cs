using Finance.Data.bdd;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Managers
{
    public class CarboneDetailsManager
    {

        private bdd_BilanCarboneDetails _bddBilanCarboneDetails { get; set; }

        public CarboneDetailsManager()
        {
            this._bddBilanCarboneDetails = new bdd_BilanCarboneDetails();
            _bddBilanCarboneDetails.SetUser(ApplicationManager.CurrentUser.UtilisateurId);
        }

        //Retourne le bilan carbone détaillé d'une année
        public BilanCarboneDetails GetBilanCarboneAnnee(int annee)
        {
            return _bddBilanCarboneDetails.Get_BilanCarboneForYear(annee);
        }


        //Ajout d'un bilan carbone détaillé
        public bool AjouterBilanCarbone(BilanCarboneDetails conso)
        {
            try
            {
                if (_bddBilanCarboneDetails.IsBilanCarbonePresent(conso))
                    _bddBilanCarboneDetails.Maj_BilanCarbone(conso);
                else
                    _bddBilanCarboneDetails.Add_BilanCarbone(conso);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
