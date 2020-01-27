using Finance.Data;
using Finance.Data.bdd;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Managers
{
    public class AppartementManager
    {

        private bdd_InfosAppartement _bddAppt { get; set; }


        public AppartementManager()
        {
            _bddAppt = new bdd_InfosAppartement();
            _bddAppt.SetUser(ApplicationManager.CurrentUser.UtilisateurId);
        }


        /// <summary>Retourne le montant de la derniére valeur de l'appartement</summary>
        /// <param name="annee">Année concerné</param>
        /// <returns>Dernier montant renseigné</returns>
        public int GetListeValeurApptPourAnnee(int annee)
        {
            return _bddAppt.Get_ValeurApptPourAnnee(annee);
        }

        /// <summary>Retourne la liste de toutes les valeurs de l'appartement</summary>
        /// <returns>Liste des valeurs</returns>
        public List<InfoAppartement> GetAllListValeursAppartement()
        {
            return _bddAppt.Get_InfosAppartementForType("Valeur");
        }

        /// <summary>Ajoute une estimation pour l'appartement</summary>
        /// <param name="estimation">Estimation</param>
        public void AjouterEstimationAppartement(InfoAppartement estimation)
        {
            _bddAppt.Add_InfoAppartement(estimation);
        }

    }
}
