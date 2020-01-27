using Finance.Business.Interface.Services;
using Finance.Business.Managers;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Carbone;

namespace Finance.Business.Services
{
    public class CarboneService : ICarboneService
    {

        private CarboneManager _CarboneManager { get; set; }
        private CarboneDetailsManager _CarboneDetailsManager { get; set; }

        public CarboneService()
        {
            this._CarboneManager = new CarboneManager();
            this._CarboneDetailsManager = new CarboneDetailsManager();
        }

        //Retourne tous les bilans carbones de l'utilisateur
        public List<BilanCarbone> GetAllBilans()
        {
            return _CarboneManager.GetAllBilanCarbone();
        }


        //Retourne le bilan carbone de l'utilisateur de l'année
        public BilanCarbone GetBilan(int annee)
        {
            return _CarboneManager.GetBilanCarboneAnnee(annee);
        }


        //Ajoute le bilan carbone d'une année en base
        public void AjouterBilanCarbone(BilanCarboneVM vm)
        {
            BilanCarbone bilan = new BilanCarbone();
            bilan.Achats = vm.Achats;
            bilan.Alimentation = vm.Alimentation;
            bilan.Annee = vm.Annee;
            bilan.Dechets = vm.Dechets;
            bilan.Finance = vm.Finance;
            bilan.Logement = vm.Logement;
            bilan.Transports = vm.Transports;
            bilan.ServicePublique = 1283;// vm.ServicePublique;

            _CarboneManager.AjouterBilanCarbone(bilan);
        }



        //Retourne un bilan carbone détaillé
        public BilanCarboneDetails GetBilanDetaille(int annee)
        {
            return _CarboneDetailsManager.GetBilanCarboneAnnee(annee);
        }

        //Ajoute un bilan carbone détaillé en base
        public void AjouterBilanCarboneDetaille(BilanCarboneDetails bil)
        {
            _CarboneDetailsManager.AjouterBilanCarbone(bil);
        }


    }
}
