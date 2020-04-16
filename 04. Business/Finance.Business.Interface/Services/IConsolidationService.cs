using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModels.Consolidation;

namespace Finance.Business.Interface.Services
{
    public interface IConsolidationService
    {
        /// <summary>Retourne la liste des mois de l'année</summary>
        /// <returns>Liste SelectListItem des mois</returns>
        List<SelectListItem> GetListMois();

        /// <summary>Retourne une liste de dépenses consolidées par catégories par mois</summary>
        /// <param name="annee">Année de recherche des dépenses</param>
        /// <param name="mois">Mois de recherche des dépenses</param>
        /// <param name="displaySsCat">Si vrai, on effectue la consolidation des sous-catégories</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Liste de dépenses consolidées</returns>
        List<ConsolidationVM> GetListConsoMensuelle(int annee, int mois, bool displaySsCat, bool isForPerso);

        /// <summary>Effectue la consolidation des totaux (impots / solde / dépenses)</summary>
        /// <param name="annee">Année de recherche des dépenses</param>
        /// <param name="mois">Mois de recherche des dépenses</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Message de retour</returns>
        string Calculer_TOTAUX(int annee, int mois, bool isForPerso);

        /// <summary>Duplique les dépenses communes vers le compte perso (montant /2)</summary>
        /// <param name="annee">Année de recherche des dépenses</param>
        /// <param name="mois">Mois de recherche des dépenses</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        void DupliquerDepensesVersPerso(int paramAnnee, int paramMois);

        /// <summary>Retourne une liste de dépenses consolidées par catégories par années</summary>
        /// <param name="annee">Année de recherche des dépenses</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Liste de dépenses consolidées</returns>
        List<ConsolidationAnnuelleVM> GetListConsoAnnuelle(int annee, bool isForPerso);

        /// <summary>Effectue les calculs de consolidation générale</summary>
        /// <param name="vm">ViewModel à mettre à jour</param>
        /// <param name="displaySsCat">Affichage des sous catégories si vrai</param>
        /// <returns>ViewModel de la page</returns>
        ConsoGeneraleVM GET_RecapGeneral(ConsoGeneraleVM vm, bool displaySsCat);

        /// <summary>Retourne la liste des dépenses totales par catégories et sous catégories</summary>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Liste des montants pour chaque cat / ssCat</returns>
        List<ConsolidationVM> GET_RecapGeneralTotal(bool isForPerso);

        /// <summary>Retourne le montant des dépenses de la sous-catégorie pour une année</summary>
        /// <param name="annee">Année de recherche</param>
        /// <param name="ssCat">Ssous-catégorie de recherche</param>
        /// <returns>Montant</returns>
        decimal GetMontantSsCatAnnee(int annee, string ssCat);

        /// <summary>Retourne le montant des dépenses de la sous-catégorie d'une année par mois</summary>
        /// <param name="annee">Année de recherche</param>
        /// <param name="ssCat">Ssous-catégorie de recherche</param>
        /// <returns>Liste des montants mensuels</returns>
        List<decimal> GetListMontantSsCatAnnee(int annee, string ssCat);

        /// <summary>Retourne le montant des dépenses de la catégorie pour une année</summary>
        /// <param name="annee">Année de recherche</param>
        /// <param name="cat">Catégorie de recherche</param>
        /// <returns>Montant</returns>
        decimal GetMontantCatAnnee(int annee, string cat);

        /// <summary>Retourne le montant des dépenses par mois de la catégorie pour une année</summary>
        /// <param name="annee">Année de recherche</param>
        /// <param name="cat">Catégorie de recherche</param>
        /// <returns>Montant</returns>
        List<decimal> GetListMontantCatAnnee(int annee, string cat);

        /// <summary>Retourne le montant des dépenses de la catégorie pour un mois</summary>
        /// <param name="annee">Année de recherche</param>
        /// <param name="mois">Mois de recherche</param>
        /// <param name="cat">catégorie de recherche</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Montant</returns>
        decimal GetMontantCatMois(int annee, int mois, string cat);
    }
}
