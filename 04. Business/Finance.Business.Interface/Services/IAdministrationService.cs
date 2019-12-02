using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Interface.Services
{
    public interface IAdministrationService
    {

        /// <summary>Retourne toutes les catégories de dépenses</summary>
        /// <returns>Liste</returns>
        List<CategorieDepense> GetAllCategoriesDepenses();

        /// <summary>Ajoute une catégorie dépense en base</summary>
        /// <param name="libelle">Nom de la catégorie dépense</param>
        /// <param name="nomCat">Catégorie concernée</param>
        /// <param name="nomSsCat">Sous-catégorie concernée</param> 
        /// <returns>Vrai si ajout</returns>
        bool AjouterCategorieDepense(string libelle, string nomCat, string nomSsCat);

        /// <summary>Retourne la liste des comptes d'un utilisateur</summary>
        /// <param name="user">Utilisateur concerné</param> 
        /// <returns>Liste de comptes</returns>
        List<Ref_Compte> GetListComptesForuser(string user);

        /// <summary>Ajoute un nouveau compte</summary>
        /// <param name="libelleCompte">Nom du compte</param> 
        /// <param name="user">Utilisateur concerné</param> 
        void AddCompteForUser(string libelleCompte, string user);

        /// <summary>Suppression un nouveau compte</summary>
        /// <param name="compteId">Id du compte à supprimer</param> 
        void SupprimerComtpe(int compteId);
    }
}
