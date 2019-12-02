using Finance.Data.bdd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Managers
{
    public class CategoriesManager
    {

        public bdd_Categories _bdd_Categories { get; set; }

        public CategoriesManager()
        {
            this._bdd_Categories = new bdd_Categories();
        }


        /// <summary>Retourne la liste des noms des catégories</summary>
        /// <returns>Liste des noms des catégories</returns>
        public List<string> GetAllListSsCategoriesString()
        {
            return _bdd_Categories.get_Categories();
        }


        /// <summary>Retourne le nom des sous catégories de la catégorie</summary>
        /// <param name="cat">Categorie concernée</param>
        /// <returns>Liste des noms des sous-catégories</returns>
        public List<string> GetListSsCategoriesStringFromCategorie(string cat)
        {
            return _bdd_Categories.get_SousCategoriesFromCategorieString(cat);
        }





    }
}
