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
            _bddBilanCarbone.SetUser(ApplicationManager.CurrentUser.UtilisateurId);
        }

        //Retourne le bilan carbone d'une année
        public BilanCarbone GetBilanCarboneAnnee(int annee)
        {
            return _bddBilanCarbone.Get_BilanCarboneForYear(annee);
        }


        //Retourne tous les bilans carbone de l'utilisateur
        public List<BilanCarbone> GetAllBilanCarbone()
        {
            return _bddBilanCarbone.Get_All();
        }


        //Ajout d'un bilan carbone
        public bool AjouterBilanCarbone(BilanCarbone conso)
        {
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
