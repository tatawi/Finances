using Finance.Business.Interface.Services;
using Finance.Business.Managers;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels.Epargne;

namespace Finance.Business.Services
{
    public class EpargneService : IEpargneService
    {
        private EpargneManager _EpargneManager { get; set; }

        public EpargneService()
        {
            _EpargneManager = new EpargneManager();
        }


        //Retourne le montant total épargné pour chaque mois de l'année
        public List<Epargne> GetEpargneparMois(int annee, string user)
        {
            List<Epargne> list_epargne = new List<Epargne>();
            List<Epargne> list_all = _EpargneManager.GetEpargnesForYearAndDecember(annee, user);
            int montantMoisprecedent = 0;

            for (int mois = 1; mois <= 12; mois++)
            {
                List<Epargne> list_mois = list_all.Where(d => d.Date.Value.Year == annee && d.Date.Value.Month == mois).ToList();
                int montantEpargneMois = _EpargneManager.GetMontantTotal(list_mois);

                if (mois == 1)
                {
                    List<Epargne> list_moisPrecedent = list_all.Where(d => d.Date.Value.Year == annee - 1 && d.Date.Value.Month == 12).ToList();
                    montantMoisprecedent = _EpargneManager.GetMontantTotal(list_moisPrecedent);
                    if (montantMoisprecedent == 0)
                        montantMoisprecedent = montantEpargneMois;
                }

                int epargne = montantEpargneMois != 0 ? (montantEpargneMois - montantMoisprecedent) : 0;

                Epargne ep = new Epargne();
                ep.Montant = epargne;
                ep.Date = new DateTime(annee, mois, 25);
                list_epargne.Add(ep);
                montantMoisprecedent = montantEpargneMois;
            }

            return list_epargne;
        }


        //Retourne la liste des comptes avec les derniers montants en base
        public List<Epargne> GetDernierMontantComptes(string user)
        {
            return _EpargneManager.GetDernierMontantComptes(user);
        }


        //Récupére l'épargne max de chaque comtpe pour une année
        public List<Epargne> GetEpargneTotaleAnnee(int annee, string user, bool AfficherCompte=false)
        {
            List<Epargne> listeEpargneTotale = new List<Epargne>();
            List<Ref_Compte> listeComtpes = _EpargneManager.GetListComptesForUser(user);

            foreach(var cpt in listeComtpes)
            {
                Epargne ep = _EpargneManager.GetEpargneTotalComptePourAnnee(annee, cpt.Ref_CompteId);
                if(AfficherCompte)
                    ep.Compte = _EpargneManager.GetCompte(cpt.Ref_CompteId);
                listeEpargneTotale.Add(ep);
            }

            return listeEpargneTotale;
        }


        //Sauvegarde d el'épargne
        public void SauvegarderEpargne(MontantsComptesVM vm)
        {
            foreach(var cpt in vm.ListeComptes)
            {
                Epargne ep = new Epargne();
                ep.CompteId = cpt.CompteId;
                ep.Montant = cpt.Montant;
                ep.Date = vm.Date;

                _EpargneManager.EnregistrerEpargne(ep);
            }
        }


    }
}
