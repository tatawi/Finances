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
    public class ConsoEauService : IConsoEauService
    {
        private ConsoEauManager _ConsoEauManager { get; set; }


        public ConsoEauService()
        {
            _ConsoEauManager = new ConsoEauManager();
        }


        public ConsommationEauAnnuelleVM GetConsommationEauAnnee(int annee)
        {
            ConsommationEauAnnuelleVM conso = new ConsommationEauAnnuelleVM();
            List<ConsoEau> listConso = _ConsoEauManager.GetAllConsoEauForYear(annee);
            conso.Annee = annee;
            decimal montantTotal = 0;
            decimal consoTotale = 0;

            foreach(ConsoEau c in listConso)
            {
                montantTotal += c.Montant ?? 0;
                consoTotale += c.Conso ?? 0;

                if(c.Type==EnumEau.TypeChaud)
                {
                    if (c.Emplacement == EnumEau.EmplCuisine)
                    {
                        conso.MontantCuisineChaud = c.Montant??0;
                        conso.ConsoCuisineChaud = c.Conso ?? 0;
                    }
                    if (c.Emplacement == EnumEau.EmplSdb)
                    {
                        conso.MontantSdbChaud = c.Montant ?? 0;
                        conso.ConsoSdbChaud = c.Conso ?? 0;
                    }
                }
                else
                {
                    if (c.Emplacement == EnumEau.EmplCuisine)
                    {
                        conso.MontantCuisineFroid = c.Montant ?? 0;
                        conso.ConsoCuisineFroid = c.Conso ?? 0;
                    }
                    if (c.Emplacement == EnumEau.EmplSdb)
                    {
                        conso.MontantSdbFroid = c.Montant ?? 0;
                        conso.ConsoSdbFroid = c.Conso ?? 0;
                    }
                    if (c.Emplacement == EnumEau.EmplWc)
                    {
                        conso.MontantWcFroid = c.Montant ?? 0;
                        conso.ConsoWcFroid = c.Conso ?? 0;
                    }
                }
            }
            conso.MontantTOTAL = montantTotal;
            conso.ConsoTOTAL = consoTotale;

            return conso;
        }


        public List<ConsommationEauAnnuelleVM> GetConsommationEau()
        {
            List<ConsommationEauAnnuelleVM> listConsos = new List<ConsommationEauAnnuelleVM>();

            for(int an=2017; an<DateTime.Now.Year; an++)
            {
                listConsos.Add(this.GetConsommationEauAnnee(an));
            }

            return listConsos;
        }


        public bool PostConsommationAnnee(ConsommationEauAnnuelleVM vm)
        {
            bool success = true;
            ConsoEau cuisineFroid = new ConsoEau {
                Annee =vm.Annee, Emplacement =EnumEau.EmplCuisine, Type =EnumEau.TypeFroid,
                Montant=vm.MontantCuisineFroid, Conso=vm.ConsoCuisineFroid
            };
            success=_ConsoEauManager.AjouterConsommation(cuisineFroid);
            if (!success) return false;

            ConsoEau cuisineChaud = new ConsoEau {
                Annee = vm.Annee, Emplacement = EnumEau.EmplCuisine, Type = EnumEau.TypeChaud,
                Montant = vm.MontantCuisineChaud, Conso = vm.ConsoCuisineChaud
            };
            success = _ConsoEauManager.AjouterConsommation(cuisineChaud);
            if (!success) return false;

            ConsoEau sdbFroid = new ConsoEau {
                Annee = vm.Annee, Emplacement = EnumEau.EmplSdb, Type = EnumEau.TypeFroid,
                Montant = vm.MontantSdbFroid, Conso = vm.ConsoSdbFroid
            };
            success = _ConsoEauManager.AjouterConsommation(sdbFroid);
            if (!success) return false;

            ConsoEau sdbChaud = new ConsoEau {
                Annee = vm.Annee, Emplacement = EnumEau.EmplSdb, Type = EnumEau.TypeChaud,
                Montant = vm.MontantSdbChaud, Conso = vm.ConsoSdbChaud
            };
            success = _ConsoEauManager.AjouterConsommation(sdbChaud);
            if (!success) return false;

            ConsoEau wcFroid = new ConsoEau {
                Annee = vm.Annee, Emplacement = EnumEau.EmplWc, Type = EnumEau.TypeFroid,
                Montant = vm.MontantWcFroid, Conso = vm.ConsoWcFroid
            };
            success = _ConsoEauManager.AjouterConsommation(wcFroid);
            if (!success) return false;

            return true;

        }


    }
}
