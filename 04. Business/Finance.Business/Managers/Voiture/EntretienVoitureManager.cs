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
    public class EntretienVoitureManager
    {
        private bdd_EntretienVoiture _bddAppt { get; set; }


        public EntretienVoitureManager()
        {
            _bddAppt = new bdd_EntretienVoiture();
            _bddAppt.SetUser(ApplicationManager.CurrentUser.UtilisateurId);
        }


        /// <summary>Retourne la liste de toutes les valeurs d'entretien voiture pour l'utilisateur courant</summary>
        /// <returns>Liste des valeurs</returns>
        public List<EntretienVoiture> GetAll()
        {
            return _bddAppt.get_All();
        }

        /// <summary>Retourne la liste de toutes les valeurs d'entretien voiture pour l'utilisateur courant</summary>
        /// <param name="annee">Année de recherche</param>
        /// <returns>Liste des valeurs</returns>
        public List<EntretienVoiture> GetAllForYear(int annee)
        {
            return _bddAppt.get_AllForYear(annee);
        }

        /// <summary>Transforme un Entretien voiture en son ViewModel associé</summary>
        /// <param name="ent">Entretien à transformer au format <EntretienVoiture/></param>
        /// <returns>ViewModel de l'entretien au format <EntretienVoitureVM/></returns>
        public EntretienVoitureVM EntretienToVm(EntretienVoiture ent)
        {
            EntretienVoitureVM vm = new EntretienVoitureVM();

            vm.Date = ent.Date;
            vm.Cout = ent.Cout;
            vm.Km = ent.Km;
            vm.Description = ent.Description;
            vm.Effectue = ent.Effectue;
            vm.Type = ent.Type;

            vm.DateStr = ent.Date.HasValue ? ent.Date.Value.ToShortDateString():"Non défini";

            if(ent.Date.HasValue)
                vm.Annee = ent.Date.Value.Year;

            return vm;
        }

        public List<EntretienVoiture> GetEntretiensSuivants()
        {
            return _bddAppt.get_ProchainsEntretiens();
        }



        public void Ajouter(EntretienVoiture en)
        {
            _bddAppt.Add(en);
        }
    }
}
