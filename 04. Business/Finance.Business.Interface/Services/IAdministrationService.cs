using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Administration;
using ViewModels.Login;

namespace Finance.Business.Interface.Services
{
    public interface IAdministrationService
    {
        // -------------------------------------------------------------------------------------------------------
        // Page - Mon utilisateur

        /// <summary>Retourne les informations de l'utilisateur courant</summary>
        /// <returns>ViewModel au format <LoginVm/></returns>
        LoginVM GetVmUtilisateur();

        /// <summary>Modifier les informations de l'utilisateur courant</summary>
        /// <param name="vm">Données de la page au format <LoginVM/></param>
        /// <returns>Message de confirmation</returns>
        string ModifierIdentiteUtilisateur(LoginVM vm);

        /// <summary>Modifier le mot de passe de l'utilisateur courant</summary>
        /// <param name="vm">Données de la page au format <LoginVM/></param>
        /// <returns>Message de confirmation</returns>
        string ModifierMotDePasse(LoginVM vm);


        // -------------------------------------------------------------------------------------------------------
        // Page - Utilisateurs

        /// <summary>Retourne le view model de la page de gestion des utilisateurs</summary>
        /// <returns>View Model <UtilisateursVM/> de la page</returns>
        UtilisateursVM GetUtilisateursVm();

        /// <summary>Enregistrer les modifications de l'utilisateur</summary>
        /// <param name="user">Utilisateur <Utilisateur/> à enregistrer</param>
        /// <returns>Message d'enregistrement</returns>
        string ModifierUtilisateur(Utilisateur user);


        // -------------------------------------------------------------------------------------------------------
        // Page - Catégories dépenses

        /// <summary>Retourne toutes les catégories de dépenses</summary>
        /// <returns>Liste</returns>
        List<CategorieDepense> GetAllCategoriesDepenses();

        /// <summary>Ajoute une catégorie dépense en base</summary>
        /// <param name="libelle">Nom de la catégorie dépense</param>
        /// <param name="nomCat">Catégorie concernée</param>
        /// <param name="nomSsCat">Sous-catégorie concernée</param> 
        /// <returns>Vrai si ajout</returns>
        bool AjouterCategorieDepense(string libelle, string nomCat, string nomSsCat);


        // -------------------------------------------------------------------------------------------------------
        // Page - Comptes

        /// <summary>Retourne la liste des comptes d'un utilisateur</summary>
        /// <returns>Liste de comptes</returns>
        List<Ref_Compte> GetListComptes();

        /// <summary>Ajoute un nouveau compte</summary>
        /// <param name="libelleCompte">Nom du compte</param> 
        void AddCompte(string libelleCompte);

        /// <summary>Suppression un nouveau compte</summary>
        /// <param name="compteId">Id du compte à supprimer</param> 
        void SupprimerComtpe(int compteId);
    }
}
