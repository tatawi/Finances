using Finance.Business.Interface.Services;
using Finance.Business.Managers;
using Finance.Data;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Services
{
    public class AdministrationService : IAdministrationService
    {
        private CategorieDepenseManager _CategorieDepenseManager { get; set; }
        private EpargneManager _EpargneManager { get; set; }


        public AdministrationService()
        {
            this._CategorieDepenseManager = new CategorieDepenseManager();
            this._EpargneManager = new EpargneManager();
        }

        #region Catégories dépenses
        //Retourne la liste des cathégories
        public List<CategorieDepense> GetAllCategoriesDepenses()
        {
            List <CategorieDepense>  liste = this._CategorieDepenseManager.GetAllCategoriesDepenses();
            liste = this._CategorieDepenseManager.UpdateListeCategorieDepenses(liste);

            return liste;
        }

        //Ajout d'une catégorie dépense
        public bool AjouterCategorieDepense(string libelle, string nomCat, string nomSsCat)
        {
            if(this._CategorieDepenseManager.IsLibelleCategorieDepensePresent(libelle))
                return false;

            //Création
            CategorieDepense corresp = new CategorieDepense();
            corresp.Libelle = libelle;
            corresp.Categorie = new Ref_Categorie();
            corresp.Categorie.Nom = nomCat;
            corresp.SousCategorie = new Ref_SsCategorie(); ;
            corresp.SousCategorie.Nom = nomSsCat;
            corresp.SousCategorie.Categorie = nomSsCat;

            //Update
            this._CategorieDepenseManager.UpdateCategorieIdFromString(corresp);
            this._CategorieDepenseManager.UpdateSousCategorieIdFromString(corresp);

            //Ajout
            this._CategorieDepenseManager.AddCategorieDepense(corresp);

            return true;
        }

        #endregion


        #region Epargne

        //Get list comptes utilisateur
        public List<Ref_Compte> GetListComptesForuser(string user)
        {
            return this._EpargneManager.GetListComptesForUser(user);
        }

        //Ajout d'un compte
        public void AddCompteForUser(string libelleCompte, string user)
        {
            Ref_Compte cpt = new Ref_Compte();
            cpt.Compte = libelleCompte;
            cpt.Montant = 0;
            cpt.IsActif = true;
            cpt.UserName = user;

            this._EpargneManager.AjouterCompte(cpt);
        }

        //Supprime un compte
        public void SupprimerComtpe(int compteId)
        {
            this._EpargneManager.SupprimerCompte(compteId);
        }

        #endregion

    }
}
