using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModels.Depenses;

namespace Finance.Business.Interface.Services
{
    public interface IDepensesService
    {

        /// <summary>Ajoute une dépense en base</summary>
        /// <param name="d">dépense à ajouter</param>
        void AjouterDepenseUnitaire(AjouterDepenseUnitaireVM vm);

        /// <summary>Ajoute une liste de dépenses en base</summary>
        /// <param name="listDepenses">Liste des dépenses à ajouter</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        void AjouterDepensesMasse(List<Depense> listDepenses, bool isForPerso);

        /// <summary>Supprimer une dépense en base</summary>
        /// <param name="d">dépense à supprimer</param>
        void SupprimerDepense(int depenseId);

        /// <summary>Retourne la liste des mois de l'année</summary>
        /// <returns>liste de select list des mois</returns>
        List<SelectListItem> GetListMois();

        /// <summary>Retourne toutes les dépenses du mois</summary>
        /// <param name="annee">Année concernée</param>
        /// <param name="mois">Mois concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Liste des dépenses</returns>
        List<Depense> GetAllDepensesMois(int annee, int mois, bool isForPerso);

        /// <summary>Retourne toutes les dépenses du mois de la catégorie</summary>
        /// <param name="annee">Année concernée</param>
        /// <param name="mois">Mois concerné</param>
        /// <param name="cat">Catégorie concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Liste des dépenses</returns>
        List<Depense> GetAllDepensesMoisForCat(int annee, int mois, string cat, bool isForPerso);

        /// <summary>Retourne le nom des sous catégories de la catégorie</summary>
        /// <param name="cat">Categorie concernée</param>
        /// <returns>Liste des noms des sous-catégories</returns>
        List<string> GetListSsCategoriesStringFromCategorie(string cat);

        /// <summary>Duplique les dépenses communes du mois en dépenses persos (/2)</summary>
        /// <param name="annee">Année concernée</param>
        /// <param name="mois">Mois concerné</param>
        /// <returns>Message informatif</returns>
        string DupliquerDepensesCommunesVersPerso(int annee, int mois);

        /// <summary>Traite les données d'import en masse</summary>
        /// <param name="vm">ViewModel avec les données d'import</param>
        /// <returns>ViewModel avec les listes à jour</returns>
        AjouterDepensesMasseVM TraiterDepensesEnMasse(AjouterDepensesMasseVM vm);
    }
}
