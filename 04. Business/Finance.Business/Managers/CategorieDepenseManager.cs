using Finance.Code.Enums;
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
    public class CategorieDepenseManager
    {
        private bdd_Categories bdd_Cat { get; set; }
        private bdd_CategorieDepense bdd_CatDep { get; set; }


        public CategorieDepenseManager()
        {
            this.bdd_Cat = new bdd_Categories();
            this.bdd_CatDep = new bdd_CategorieDepense();
        }

        /// <summary>Ajoute une catégorie de dépense en base</summary>
        /// <param name="catDep">Item à ajouter</param>
        public void AddCategorieDepense(CategorieDepense catDep)
        {
            bdd_CatDep.Add_CategorieDepense(catDep);
        }


        /// <summary>Retourne toutes les catégories de dépenses</summary>
        /// <returns>Liste</returns>
        public List<CategorieDepense> GetAllCategoriesDepenses()
        {
            return this.bdd_CatDep.get_All();
        }

        /// <summary>Met à jour les objets catégories et ssCatégories de la liste</summary>
        /// <param name="liste">Liste à mettre à jour</param>
        /// <returns>Liste à jour</returns>
        public List<CategorieDepense> UpdateListeCategorieDepenses(List<CategorieDepense> liste)
        {
            foreach (var catDep in liste)
            {
                catDep.Categorie = bdd_Cat.get_CategoriesFromCategorieId(catDep.CategorieId);
                catDep.SousCategorie = bdd_Cat.get_SsCategoriesFromSsCategorieId(catDep.SousCategorieId);
            }
            return liste;
        }

        /// <summary>Permet de savoir si une catégorie de dépense existe déjà</summary>
        /// <param name="liste">libelle de la catégorie dépense</param>
        /// <returns>Vrai si présent</returns>
        public bool IsLibelleCategorieDepensePresent(string libelle)
        {
            return bdd_CatDep.IsLibellePresent(libelle);
        }

        /// <summary>Met à jour l'id de la catégorie</summary>
        /// <param name="catDep">Item à mettre à jour</param>
        public void UpdateCategorieIdFromString(CategorieDepense catDep)
        {
            catDep.CategorieId = bdd_Cat.get_CategoriesFromString(catDep.Categorie.Nom).Ref_CategorieId;
        }

        /// <summary>Met à jour l'id de la sous-catégorie</summary>
        /// <param name="catDep">Item à mettre à jour</param>
        public void UpdateSousCategorieIdFromString(CategorieDepense catDep)
        {
            catDep.SousCategorieId = bdd_Cat.get_SousCategoriesFromString(catDep.SousCategorie.Nom).Ref_SsCategorieId;
        }

        
        /// <summary>Met à jour la catégorie et la sous-catégorie d'une dépense</summary>
        /// <param name="dep">Dépense à mettre à jour</param>
        /// <returns>Dépense à jour si concernée</returns>
        public Depense RenseignerCategoriesDepense(Depense dep)
        {
            List<CategorieDepense> listCorresp = bdd_CatDep.get_All();

            foreach (CategorieDepense corresp in listCorresp)
            {
                if (dep.Libelle.ToUpper().Contains(corresp.Libelle.ToUpper()))
                {
                    dep.Categorie = bdd_Cat.get_CategoriesFromCategorieId(corresp.CategorieId).Nom;
                    dep.SousCategorie = bdd_Cat.get_SsCategoriesFromSsCategorieId(corresp.SousCategorieId).Nom;
                    return dep;
                }
            }
            return dep;
        }
    }
}
