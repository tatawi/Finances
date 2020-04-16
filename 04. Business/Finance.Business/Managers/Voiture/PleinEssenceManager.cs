using Finance.Data.bdd;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Voiture;

namespace Finance.Business.Managers.Voiture
{
    public class PleinEssenceManager
    {
        private bdd_PleinEssence _bddAppt { get; set; }


        public PleinEssenceManager()
        {
            _bddAppt = new bdd_PleinEssence();
            _bddAppt.SetUser(ApplicationManager.CurrentUser.UtilisateurId);
        }


        /// <summary>Retourne la liste de toutes les valeurs d'entretien voiture pour l'utilisateur courant</summary>
        /// <returns>Liste des valeurs</returns>
        public List<PleinEssence> GetAll()
        {
            return _bddAppt.get_All();
        }

        /// <summary>Retourne la liste de toutes les valeurs d'entretien voiture pour l'utilisateur courant</summary>
        /// <returns>derniére valeur</returns>
        public PleinEssence GetLast()
        {
            return _bddAppt.get_Last();
        }

        /// <summary>Retourne la liste de toutes les valeurs d'entretien voiture pour l'utilisateur courant</summary>
        /// <param name="annee">Année de recherche</param>
        /// <returns>Liste des valeurs</returns>
        public List<PleinEssence> GetAllForYear(int annee)
        {
            return _bddAppt.get_AllForYear(annee);
        }

        public decimal GetConsommationMoyenne()
        {
            PleinEssence first = _bddAppt.get_First();
            PleinEssence last = _bddAppt.get_Last();
            int kmParcourus = last.Km - first.Km;

            if (kmParcourus == 0)
                return 0;

            int litresConsommes = _bddAppt.get_SommeLitres();

            return ((100 * litresConsommes) / kmParcourus);
        }


        /// <summary>Ajoute un pelin d'essence en base de données</summary>
        /// <param name="pl">Plein d'essence à ajouter au format <PleinEssence/></param>
        public void Ajouter(PleinEssence pl)
        {
            _bddAppt.Add(pl);
        }

        /// <summary>Transforme un plein d'essence en son ViewModel associé</summary>
        /// <param name="pl">Plein d'essence à transformer au format <PleinEssence/></param>
        /// <returns>ViewModel du plein d'essence au format <PleinEssenceVM/></returns>
        public PleinEssenceVM PleinEssenceToVm(PleinEssence pl)
        {
            PleinEssenceVM vm = new PleinEssenceVM();

            vm.Date = pl.Date;
            vm.Conso = pl.Conso;
            vm.Km = pl.Km;
            vm.Litres = pl.Litres;
            vm.Prix = pl.Prix;
            vm.Type = pl.Type;

            if(pl.Litres!=0)
                vm.PrixLitre = (decimal)pl.Prix / (decimal)pl.Litres;
            else
                vm.PrixLitre = pl.Prix;

            vm.PrixLitreStr = vm.PrixLitre.ToString("#.###");
            vm.Jour = pl.Date.Day;
            vm.Mois = pl.Date.Month;
            vm.Annee = pl.Date.Year;
            vm.DateStr = pl.Date.ToShortDateString();

            return vm;
        }

    }
}
