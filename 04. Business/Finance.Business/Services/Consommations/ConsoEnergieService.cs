using Finance.Business.Interface.Services;
using Finance.Business.Managers;
using Finance.Helpers.Enums;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Consommation;

namespace Finance.Business.Services
{
    public class ConsoEnergieService : IConsoEnergieService
    {

        private static readonly int TemperatureEauFroide = 10;
        private static readonly int TemperatureEauChaude = 46;
        private static readonly decimal Rendement = 0.98M;
        private static readonly decimal Const1litre1degres = 1.16M;


        private ConsoElecManager _ConsoElecManager { get; set; }
        private ConsoEauManager _ConsoEauManager { get; set; }
        private ConsoChauffageManager _ConsoChauffageManager { get; set; }

        public ConsoEnergieService()
        {
            _ConsoElecManager = new ConsoElecManager();
            _ConsoEauManager = new ConsoEauManager();
            _ConsoChauffageManager = new ConsoChauffageManager();
        }


        public List<ConsommationEnergieAnnuelleVM> GetConsoEnergie(string user)
        {
            List<ConsommationEnergieAnnuelleVM> list = new List<ConsommationEnergieAnnuelleVM>();
            List<Electricite> listElec = _ConsoElecManager.GetAllElectricite(user);
            List<ConsoEau> listEau = _ConsoEauManager.GetAllConsoEau();
            List<ConsoChauffage> listChauff = _ConsoChauffageManager.GetAllInfosChauffage();

            for (int an=2017; an<=DateTime.Now.Year; an++)
            {
                ConsommationEnergieAnnuelleVM vm = new ConsommationEnergieAnnuelleVM();
                vm.Annee = an;

                //EAU
                decimal ConsoM3 = listEau.Where(e => e.Annee == an && e.Type == EnumEau.TypeChaud).Sum(e => e.Conso) ?? 0;
                decimal energiePour1m3 = (Const1litre1degres * (TemperatureEauChaude - TemperatureEauFroide) / Rendement);
                vm.ConsoEau = energiePour1m3 * ConsoM3;

                //Elec
                vm.ConsoElec = listElec.Where(e => e.Date.Value.Year == an).Sum(e => e.Consommation) ?? 0;

                //Chauffage
                vm.ConsoChauffage = listChauff.FirstOrDefault(c => c.Annee == an)?.KwhPerso ?? 0;

                vm.ConsoTotale = vm.ConsoEau + vm.ConsoElec + vm.ConsoChauffage;
                list.Add(vm);
            }

            return list;
        }



    }
}
