using Finance.Code.Enums;
using Finance.Data.bdd;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Managers
{
    public class DepensesManager
    {

        public Bdd_Depense _bdd_Depense { get; set; }
        private bdd_Categories bdd_Cat { get; set; }

        public DepensesManager()
        {
            this._bdd_Depense = new Bdd_Depense();
            this.bdd_Cat = new bdd_Categories();
        }

        /// <summary>Ajoute une dépense en base</summary>
        /// <param name="d">dépense à ajouter</param>
        public void AjouterDepenseUnitaire(Depense d, string user, bool isForPerso)
        {
            _bdd_Depense.setUser(user);
            _bdd_Depense.setCompte(isForPerso);
            _bdd_Depense.Add_Depense(d);
        }


        /// <summary>Supprimer une dépense en base</summary>
        /// <param name="d">dépense à supprimer</param>
        public void SupprimerDepense(int depenseId)
        {
            _bdd_Depense.Del_Depense(depenseId);
        }

        /// <summary>Permet de savoir si une dépense est présente en base via ses caractéristiques</summary>
        /// <param name="dep">Dépense concernée</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Vrai si une dépense correspond</returns>
        public bool IsDepensePresente(Depense dep, string user, bool isForPerso)
        {
            _bdd_Depense.setUser(user);
            _bdd_Depense.setCompte(isForPerso);
            return _bdd_Depense.IsDepensePresente(dep);
        }

        /// <summary>Permet de savoir si une dépense est présente en base via ses caractéristiques de date et de libellé</summary>
        /// <param name="dep">Dépense concernée</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Vrai si une dépense correspond</returns>
        public bool IsDepensePresenteByDateAndLib(Depense dep, string user, bool isForPerso)
        {
            _bdd_Depense.setUser(user);
            _bdd_Depense.setCompte(isForPerso);
            return _bdd_Depense.IsDepensePresenteByDateAndLib(dep);
        }

        /// <summary>Retourne toutes les dépenses du mois</summary>
        /// <param name="annee">Année concernée</param>
        /// <param name="mois">Mois concerné</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Liste des dépenses</returns>
        public List<Depense> GetAllDepensesMois(int annee, int mois, string user, bool isForPerso)
        {
            _bdd_Depense.setUser(user);
            _bdd_Depense.setCompte(isForPerso);
            return _bdd_Depense.get_DepensesMois(annee, mois);
        }


        /// <summary>Retourne toutes les dépenses du mois de la catégorie</summary>
        /// <param name="annee">Année concernée</param>
        /// <param name="mois">Mois concerné</param>
        /// <param name="cat">Catégorie concerné</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Liste des dépenses</returns>
        public List<Depense> GetAllDepensesMoisForCat(int annee, int mois, string cat, string user, bool isForPerso)
        {
            _bdd_Depense.setUser(user);
            _bdd_Depense.setCompte(isForPerso);
            return _bdd_Depense.get_DepensesMoisByCat(annee, mois, cat);
        }

        /// <summary>Met à jour la catégorie et sous catégorie d'une dépense à partir de son nom</summary>
        /// <param name="d">Dépense à mettre à jour</param>
        /// <param name="name">nom de la catégorie</param>
        /// <returns>Dépense à jour si concernée</returns>
        public Depense UpdateCatEtSsCatDepenseFromString(Depense d, string name)
        {

            if (bdd_Cat.isCategorie(name))
            {
                d.Categorie = name;

                List<string> list_ssCat = bdd_Cat.get_SousCategoriesFromCategorieString(name);
                if (list_ssCat.Count > 1)
                    d.SousCategorie = list_ssCat.FirstOrDefault();
                else
                    d.SousCategorie = EnumSousCategorie.Vide;
            }
            else
            {
                d.SousCategorie = name;
                d.Categorie = bdd_Cat.getCategorieFromSsCategorie(name);
            }

            return d;
        }

        /// <summary>Calcule le total des impots du mois</summary>
        /// <param name="annee">Année concernée</param>
        /// <param name="mois">Mois concerné</param>
        /// <param name="list_DepenseMois">Liste de travail</param>
        /// <param name = "user" > Utilisateur concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        public void Calculate_TotalImpotsFor(int annee, int mois, List<Depense> list_DepenseMois, string user, bool isForPerso)
        {
            _bdd_Depense.setUser(user);
            _bdd_Depense.setCompte(isForPerso);
            _bdd_Depense.Calculate_TotalImpotsFor(annee, mois, list_DepenseMois);
        }

        /// <summary>met à jour le solde du mois</summary>
        /// <param name="annee">Année concernée</param>
        /// <param name="mois">Mois concerné</param>
        /// <param name="list_DepenseMois">Liste de travail</param>
        /// <param name="totalDepenses">Montant total dépensé du mois</param>
        /// <param name = "user" > Utilisateur concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        public void Calculate_SoldeFor(int annee, int mois, List<Depense> list_DepenseMois, decimal totalDepenses, string user, bool isForPerso)
        {
            _bdd_Depense.setUser(user);
            _bdd_Depense.setCompte(isForPerso);
            _bdd_Depense.Calculate_SoldeFor(annee, mois, list_DepenseMois, totalDepenses);
        }

        /// <summary>Retourne le montant des dépenses de la liste selon l'année et le mois</summary>
        /// <param name="annee">Année concernée</param>
        /// <param name="mois">Mois concerné</param>
        /// <param name="list_DepenseMois">Liste de travail</param>
        /// <param name = "user" > Utilisateur concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Montant</returns>
        public decimal Calculate_TotalDepensesFor(int annee, int mois, List<Depense> list_DepenseMois, string user, bool isForPerso)
        {
            _bdd_Depense.setUser(user);
            _bdd_Depense.setCompte(isForPerso);
            return _bdd_Depense.Calculate_TotalDepensesFor(annee, mois, list_DepenseMois);
        }

        /// <summary>Retourne le montant des dépenses de la catégorie pour une année</summary>
        /// <param name="annee">Année de recherche</param>
        /// <param name="cat">Catégorie de recherche</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Montant</returns>
        public decimal Get_MontantCatAnnee(int annee, string cat, string user, bool isForPerso)
        {
            _bdd_Depense.setUser(user);
            _bdd_Depense.setCompte(isForPerso);
            return _bdd_Depense.get_MontantCatAnnee(annee, cat);
        }

        /// <summary>Retourne le montant des dépenses de la sous-catégorie pour un mois</summary>
        /// <param name="annee">Année de recherche</param>
        /// <param name="mois">Mois de recherche</param>
        /// <param name="ssCat">Ssous-catégorie de recherche</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Montant</returns>
        public decimal Get_MontantSsCatAnnee(int annee, string ssCat, string user, bool isForPerso)
        {
            _bdd_Depense.setUser(user);
            _bdd_Depense.setCompte(isForPerso);
            return _bdd_Depense.get_MontantSsCatAnnee(annee, ssCat);
        }

        /// <summary>Retourne le montant des dépenses de la catégorie pour un mois</summary>
        /// <param name="annee">Année de recherche</param>
        /// <param name="mois">Mois de recherche</param>
        /// <param name="cat">catégorie de recherche</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Montant</returns>
        public decimal Get_MontantCatMois(int annee, int mois, string cat, string user, bool isForPerso)
        {
            _bdd_Depense.setUser(user);
            _bdd_Depense.setCompte(isForPerso);
            return _bdd_Depense.get_MontantCatMois(annee, mois, cat);
        }

        /// <summary>Retourne le montant des dépenses de la sous-catégorie pour un mois</summary>
        /// <param name="annee">Année de recherche</param>
        /// <param name="mois">Mois de recherche</param>
        /// <param name="ssCat">Sous-catégorie de recherche</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <param name="isForPerso">Affichage compte perso ou commun</param>
        /// <returns>Montant</returns>
        public decimal Get_MontantSsCatMois(int annee, int mois, string ssCat, string user, bool isForPerso)
        {
            _bdd_Depense.setUser(user);
            _bdd_Depense.setCompte(isForPerso);
            return _bdd_Depense.get_MontantSsCatMois(annee, mois, ssCat);
        }
    }
}
