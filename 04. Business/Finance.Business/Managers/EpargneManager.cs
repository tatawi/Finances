using System.Collections.Generic;
using System.Linq;
using Finance.Data;
using Finance.Data.bdd;
using Finance.Poco;

namespace Finance.Business.Managers
{
    public class EpargneManager
    {
        public bdd_Epargne _bddEpargne { get; set; }

        public EpargneManager()
        {
            _bddEpargne = new bdd_Epargne();
        }


        #region GET

        /// <summary>Recupére la liste des comptes de l'utilisateur</summary>
        /// <param name="user">Utilisateur concerné</param>
        /// <returns>Liste de comptes</returns>
        public List<Ref_Compte> GetListComptesForUser(string user)
        {
            _bddEpargne.SetUser(user);
            return _bddEpargne.Get_Comptes();
        }


        /// <summary>Retourne un compte à partir du compteId</summary>
        /// <param name="compteId">ID du compte à retoruner</param>
        /// <returns>Compte</returns>
        public Ref_Compte GetCompte(int compteId)
        {
            return _bddEpargne.get_CompteFromId(compteId);
        }


        /// <summary>Retourne le montant total épargné pour chaque mois de l'année</summary>
        /// <param name="annee">Année de recherche</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <returns>Un objet par mois de l'année avec la date et le montant épargné</returns>
        public List<Epargne> GetEpargnesForYearAndDecember(int annee, string user)
        {
            _bddEpargne.SetUser(user);
            return _bddEpargne.Get_EpargnesForYearAndDecember(annee);
        }


        /// <summary>Calcule la somme de l'épargne en prenant la valeur la plus récente pour chaque compte</summary>
        /// <param name="list">Liste dont il faut calculer le total</param>
        /// <returns>Montant total pour la liste</returns>
        public int GetMontantTotal(List<Epargne> list)
        {
            int montantTotalEpargne = 0;
            List<int> list_comptes = list.Select(x => x.CompteId).Distinct().ToList();

            foreach (int cpt in list_comptes)
            {
                Epargne cptMax = list.Where(c => c.CompteId == cpt).OrderByDescending(c => c.Date).FirstOrDefault();
                montantTotalEpargne += cptMax.Montant.HasValue ? cptMax.Montant.Value : 0;
            }

            return montantTotalEpargne;
        }


        /// <summary>Retourne la liste des comptes avec les derniers montants en base</summary>
        /// <param name="user">Utilisateur concerné</param>
        /// <returns>Liste de tous les comptes de l'utilisateur avec le montant reneigné</returns>
        public List<Epargne> GetDernierMontantComptes(string user)
        {
            _bddEpargne.SetUser(user);
            List<Epargne> list_MontantComtpes = new List<Epargne>();
            List<Ref_Compte> list_comtpes = _bddEpargne.Get_Comptes();

            foreach (Ref_Compte cpt in list_comtpes)
            {
                Epargne montantCompte = new Epargne();
                montantCompte.CompteId = cpt.Ref_CompteId;
                montantCompte.Compte = cpt;
                montantCompte.Montant = _bddEpargne.Get_MontantCompte(cpt.Ref_CompteId);

                list_MontantComtpes.Add(montantCompte);
            }
            return list_MontantComtpes;
        }


        /// <summary>Retourne le montant total épargné pour chaque mois de l'année</summary>
        /// <param name="annee">Année de recherche</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <returns>Un objet par mois de l'année avec la date et le montant épargné</returns>
        public Epargne GetEpargneTotalComptePourAnnee(int annee, int compteId)
        {
            return _bddEpargne.Get_DerniereEpargnePourAnnee(compteId, annee);
        }

        #endregion



        #region INSERT
        /// <summary>Enregistre une ligne d'épargne en base</summary>
        /// <param name="compte">Epargne pour le compte concernée</param>
        public void EnregistrerEpargne(Epargne compte)
        {
            _bddEpargne.Add_Operation(compte);
        }

        /// <summary>Ajout d'un compte en base</summary>
        /// <param name="cpt">Comtpe à ajouter</param>
        public void AjouterCompte(Ref_Compte cpt)
        {
            _bddEpargne.Add_Compte(cpt);
        }

        /// <summary>Suppression d'un compte en base</summary>
        /// <param name="compteId">Id du comtpe à supprimer</param>
        public void SupprimerCompte(int compteId)
        {
            _bddEpargne.Del_Compte(compteId);
        }

        #endregion


    }
}
