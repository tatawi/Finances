using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Epargne;

namespace Finance.Business.Interface.Services
{
    /// <summary>Gestion de la partie épargne de l'application Finance</summary>
    public interface IEpargneService
    {

        /// <summary>Retourne le montant total épargné pour chaque mois de l'année</summary>
        /// <param name="annee">Année de recherche</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <returns>Un objet par mois de l'année avec la date et le montant épargné</returns>
        List<Epargne> GetEpargneparMois(int annee, string user);


        /// <summary>Retourne la liste des comptes avec les derniers montants en base</summary>
        /// <param name="user">Utilisateur concerné</param>
        /// <returns>Liste de tous les comptes de l'utilisateur avec le montant reneigné</returns>
        List<Epargne> GetDernierMontantComptes(string user);


        /// <summary>Sauvegarde une liste d'épargne pour une date donnée</summary>
        /// <param name="vm">ViewModel contenant la date et la liste des comtpes avec leur nouveaux montants</param>
        void SauvegarderEpargne(MontantsComptesVM vm);


        /// <summary>Retourne la liste des derniers montants pour chaque compte sur une année</summary>
        /// <param name="annee">Année concernée</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <param name="AfficherCompte">Permet de renseigner l'object Compte de chaque Epargnes dans la liste</param>
        /// <returns>Liste des derniers comptes renseignés</returns>
        List<Epargne> GetEpargneTotaleAnnee(int annee, string user, bool AfficherCompte = false);
    }
}
