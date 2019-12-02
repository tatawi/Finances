﻿using System;
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
        /// <param name="user">Utilisateur concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Liste de dépenses consolidées</returns>
        List<ConsolidationVM> GetListConsoMensuelle(int annee, int mois, bool displaySsCat, string user, bool isForPerso);

        /// <summary>Effectue la consolidation des totaux (impots / solde / dépenses)</summary>
        /// <param name="annee">Année de recherche des dépenses</param>
        /// <param name="mois">Mois de recherche des dépenses</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Message de retour</returns>
        string Calculer_TOTAUX(int annee, int mois, string user, bool isForPerso);

        /// <summary>Duplique les dépenses communes vers le compte perso (montant /2)</summary>
        /// <param name="annee">Année de recherche des dépenses</param>
        /// <param name="mois">Mois de recherche des dépenses</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        void DupliquerDepensesVersPerso(int paramAnnee, int paramMois, string user);

        /// <summary>Retourne une liste de dépenses consolidées par catégories par années</summary>
        /// <param name="annee">Année de recherche des dépenses</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Liste de dépenses consolidées</returns>
        List<ConsolidationAnnuelleVM> GetListConsoAnnuelle(int annee, string user, bool isForPerso);

        /// <summary>Effectue les calculs de consolidation générale</summary>
        /// <param name="vm">ViewModel à mettre à jour</param>
        /// <param name="displaySsCat">Affichage des sous catégories si vrai</param>
        /// <returns>ViewModel de la page</returns>
        ConsoGeneraleVM GET_RecapGeneral(ConsoGeneraleVM vm, bool displaySsCat);

        /// <summary>Retourne le montant des dépenses de la sous-catégorie pour un mois</summary>
        /// <param name="annee">Année de recherche</param>
        /// <param name="mois">Mois de recherche</param>
        /// <param name="ssCat">Ssous-catégorie de recherche</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <returns>Montant</returns>
        decimal GetMontantSsCatAnnee(int annee, string ssCat, string user);

        /// <summary>Retourne le montant des dépenses de la catégorie pour une année</summary>
        /// <param name="annee">Année de recherche</param>
        /// <param name="cat">Catégorie de recherche</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Montant</returns>
        decimal GetMontantCatAnnee(int annee, string cat, string user);

        /// <summary>Retourne le montant des dépenses de la catégorie pour un mois</summary>
        /// <param name="annee">Année de recherche</param>
        /// <param name="mois">Mois de recherche</param>
        /// <param name="cat">catégorie de recherche</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Montant</returns>
        decimal GetMontantCatMois(int annee, int mois, string cat, string user);
    }
}
