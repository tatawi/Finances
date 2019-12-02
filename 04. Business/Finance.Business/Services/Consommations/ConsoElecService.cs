using Finance.Business.Interface.Services;
using Finance.Business.Managers;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Consommation;

namespace Finance.Business.Services
{
    public class ConsoElecService : IConsoElecService
    {
        private ConsoElecManager _ConsoElecManager { get; set; }

        public ConsoElecService()
        {
            this._ConsoElecManager = new ConsoElecManager();
        }

        

        public ConsommationElecAnnuelle GetConsoElecAnnee(int annee, string user)
        {
            ConsommationElecAnnuelle consoA = new ConsommationElecAnnuelle();
            List<Electricite> listConsos = _ConsoElecManager.GetAllElectriciteForYear(annee, user);

            foreach(Electricite c in listConsos)
            {
                ConsommationElecMensuelle consoM = new ConsommationElecMensuelle();
                consoM.Annee = annee;
                consoM.Mois = c.Date.Value.Month;
                consoM.MoisStr=c.Date.Value.ToString("MMMM");
                consoM.Montant = c.Montant??0;
                consoM.Consommation = c.Consommation??0;

                if (!consoA.listeConsoMois.Any(v => v.Mois == consoM.Mois))
                    consoA.listeConsoMois.Add(consoM);

            }
            consoA.Annee = annee;
            consoA.Montant = consoA.listeConsoMois.Sum(v => v.Montant);
            consoA.Consommation = consoA.listeConsoMois.Sum(v => v.Consommation);

            return consoA;
        }

        public List<ConsommationElecAnnuelle> GetAllConsosElec (string user)
        {
            List<ConsommationElecAnnuelle> listeConsos = new List<ConsommationElecAnnuelle>();

            for (int an=2017; an<=DateTime.Now.Year; an++)
            {
                listeConsos.Add(this.GetConsoElecAnnee(an, user));
            }
            return listeConsos;
        }


        public bool PostConsommationAnnee(_ConsoElec_POST vm, string user)
        {
            bool success = true;

            Electricite e1 = new Electricite {Date= new DateTime(vm.Annee, 1, 1), Montant =vm.chp_consoElec_M1, Consommation=vm.chp_consoElec_C1, Description="", PrixKwh=0 };
            success = _ConsoElecManager.AjouterConsommation(e1, user);
            if (!success) return false;

            Electricite e2 = new Electricite { Date = new DateTime(vm.Annee, 2, 1), Montant = vm.chp_consoElec_M2, Consommation = vm.chp_consoElec_C2, Description = "", PrixKwh = 0 };
            success = _ConsoElecManager.AjouterConsommation(e2, user);
            if (!success) return false;

            Electricite e3 = new Electricite { Date = new DateTime(vm.Annee, 3, 1), Montant = vm.chp_consoElec_M3, Consommation = vm.chp_consoElec_C3, Description = "", PrixKwh = 0 };
            success = _ConsoElecManager.AjouterConsommation(e3, user);
            if (!success) return false;

            Electricite e4 = new Electricite { Date = new DateTime(vm.Annee, 4, 1), Montant = vm.chp_consoElec_M4, Consommation = vm.chp_consoElec_C4, Description = "", PrixKwh = 0 };
            success = _ConsoElecManager.AjouterConsommation(e4, user);
            if (!success) return false;

            Electricite e5 = new Electricite { Date = new DateTime(vm.Annee, 5, 1), Montant = vm.chp_consoElec_M5, Consommation = vm.chp_consoElec_C5, Description = "", PrixKwh = 0 };
            success = _ConsoElecManager.AjouterConsommation(e5, user);
            if (!success) return false;

            Electricite e6 = new Electricite { Date = new DateTime(vm.Annee, 6, 1), Montant = vm.chp_consoElec_M6, Consommation = vm.chp_consoElec_C6, Description = "", PrixKwh = 0 };
            success = _ConsoElecManager.AjouterConsommation(e6, user);
            if (!success) return false;

            Electricite e7 = new Electricite { Date = new DateTime(vm.Annee, 7, 1), Montant = vm.chp_consoElec_M7, Consommation = vm.chp_consoElec_C7, Description = "", PrixKwh = 0 };
            success = _ConsoElecManager.AjouterConsommation(e7, user);
            if (!success) return false;

            Electricite e8 = new Electricite { Date = new DateTime(vm.Annee, 8, 1), Montant = vm.chp_consoElec_M8, Consommation = vm.chp_consoElec_C8, Description = "", PrixKwh = 0 };
            success = _ConsoElecManager.AjouterConsommation(e8, user);
            if (!success) return false;

            Electricite e9 = new Electricite { Date = new DateTime(vm.Annee, 9, 1), Montant = vm.chp_consoElec_M9, Consommation = vm.chp_consoElec_C9, Description = "", PrixKwh = 0 };
            success = _ConsoElecManager.AjouterConsommation(e9, user);
            if (!success) return false;

            Electricite e10 = new Electricite { Date = new DateTime(vm.Annee, 10, 1), Montant = vm.chp_consoElec_M10, Consommation = vm.chp_consoElec_C10, Description = "", PrixKwh = 0 };
            success = _ConsoElecManager.AjouterConsommation(e10, user);
            if (!success) return false;

            Electricite e11 = new Electricite { Date = new DateTime(vm.Annee, 11, 1), Montant = vm.chp_consoElec_M11, Consommation = vm.chp_consoElec_C11, Description = "", PrixKwh = 0 };
            success = _ConsoElecManager.AjouterConsommation(e11, user);
            if (!success) return false;

            Electricite e12 = new Electricite { Date = new DateTime(vm.Annee, 12, 1), Montant = vm.chp_consoElec_M12, Consommation = vm.chp_consoElec_C12, Description = "", PrixKwh = 0 };
            success = _ConsoElecManager.AjouterConsommation(e12, user);
            if (!success) return false;

            return success;
        }


    }
}
