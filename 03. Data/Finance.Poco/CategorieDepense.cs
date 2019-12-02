using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finance.Poco
{
    public class CategorieDepense
    {
        public int CategorieDepenseId;
        public string Libelle;
        public int CategorieId;
        public Ref_Categorie Categorie;
        public int SousCategorieId;
        public Ref_SsCategorie SousCategorie;


        public CategorieDepense()
        {

        }

       /* public CategorieDepense(int paramCategorieDepenseId, string paramLibelle, int paramCategorieId, int paramSousCategorieId)
        {
            this.CategorieDepenseId = paramCategorieDepenseId;
            this.Libelle = paramLibelle;
            this.CategorieId = paramCategorieId;
            this.SousCategorieId = paramSousCategorieId;

            bdd_Categories bddCategories = new bdd_Categories();
            Ref_SsCategorie sscat = bddCategories.get_SsCategoriesFromSsCategorieId(this.SousCategorieId);

            if(sscat != null)
            {
                Ref_Categorie cat = new Ref_Categorie();
                cat.Nom = sscat.Nom;
                this.Categorie = cat;
                this.SousCategorie = sscat;
            }
        }*/


       /* public void UpdateCat()
        {
            bdd_Categories bddCategories = new bdd_Categories();
            Ref_SsCategorie sscat = bddCategories.get_SsCategoriesFromSsCategorieId(this.SousCategorieId);

            if (sscat != null)
            {
                Ref_Categorie cat = new Ref_Categorie();
                cat.Nom = sscat.Categorie;
                this.Categorie = cat;
                this.SousCategorie = sscat;
            }
        }*/

       /* public void UpdateCatIdsFromString()
        {
            bdd_Categories bddCategories = new bdd_Categories();
            this.CategorieId = bddCategories.get_CategoriesFromString(this.Categorie.Nom).Ref_CategorieId;
            this.SousCategorieId = bddCategories.get_SousCategoriesFromString(this.SousCategorie.Nom).Ref_SsCategorieId;
        }*/

    }
}