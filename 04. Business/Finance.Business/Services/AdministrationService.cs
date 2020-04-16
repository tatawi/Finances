using Finance.Business.Interface.Services;
using Finance.Business.Managers;
using Finance.Data;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Administration;
using ViewModels.Login;

namespace Finance.Business.Services
{
    public class AdministrationService : IAdministrationService
    {
        private CategorieDepenseManager _CategorieDepenseManager { get; set; }
        private EpargneManager _EpargneManager { get; set; }
        private UtilisateurManager _UtilisateurManager { get; set; }
        private MailService mailService { get; set; }


        public AdministrationService()
        {
            this._CategorieDepenseManager = new CategorieDepenseManager();
            this._EpargneManager = new EpargneManager();
            this._UtilisateurManager = new UtilisateurManager();
            this.mailService = new MailService();
        }


        #region Mon Utilisateur

        //Get vm page
        public LoginVM GetVmUtilisateur()
        {
            LoginVM vm = new LoginVM();
            Utilisateur monUser = ApplicationManager.CurrentUser;
            vm.newNom = monUser.Nom;
            vm.newPrenom = monUser.Prenom;
            vm.newMail = monUser.Email;
            vm.isActif = monUser.IsActif;

            return vm;
        }
        
        //Modification identité utilisateur
        public string ModifierIdentiteUtilisateur(LoginVM vm)
        {
            if(vm==null)
                return "[Erreur]Une erreur est survenue";

            if (vm.newNom != "" && vm.newPrenom != "")
            {
                Utilisateur user = ApplicationManager.CurrentUser;

                if(user.Nom != vm.newNom)
                    user.Nom = vm.newNom;

                if(user.Prenom != vm.newPrenom)
                    user.Prenom = vm.newPrenom;

                bool result = _UtilisateurManager.MajUtilisateur(user);

                if (result)
                    return "L'utilisateur a bien été modifié";
                else
                    return "[Erreur]Erreur lors de la mise à jour de l'utilisateur";
            }
            else
                return "[Erreur]Cette action n'est pas autorisée";
        }

        //Modification mot de passe utilisateur
        public string ModifierMotDePasse(LoginVM vm)
        {
            if (vm == null)
                return "[Erreur]Une erreur est survenue";

            if(vm.newMdp == "" || vm.newConfirmMdp == "")
                return "[Erreur]Une erreur est survenue";

            if (!_UtilisateurManager.IsMotDePasseConforme(vm.newMdp))
                return "[Erreur]Le mot de passe n'est pas valide";

            //Utilisateur
            Utilisateur user = ApplicationManager.CurrentUser;

            //Maj MDP
            user.MotDePasse = _UtilisateurManager.Encrypt(vm.newMdp);


            bool result = _UtilisateurManager.MajUtilisateur(user);

            if (result)
            {
                //Envoie mail
                mailService.MailChangementMdp(user.Email);
                return "Le mot de passe a été changé";
            }
            else
                return "[Erreur]Erreur lors de la mise à jour du mot de passe";
        }

        #endregion

        #region Utilisateurs

        public UtilisateursVM GetUtilisateursVm()
        {
            UtilisateursVM vm = new UtilisateursVM();
            vm.listUsers = _UtilisateurManager.GetUtilisateurs();

            return vm;
        }

        public string ModifierUtilisateur(Utilisateur user)
        {
            if (user == null || user.Email == "")
                return "[Erreur]Une erreur est survenue";

            //Get user
            Utilisateur userToMaj = _UtilisateurManager.GetUtilisateur(user.Email);

            if(userToMaj == null || userToMaj.UtilisateurId != user.UtilisateurId)
                return "[Erreur]Impossile de trouver l'utilisateur à mettre à jour";

            //Maj user
            #region Maj
            if (user.Nom != userToMaj.Nom)
                userToMaj.Nom = user.Nom;
            if (user.Prenom != userToMaj.Prenom)
                userToMaj.Prenom = user.Prenom;
            if (user.DoitChangerMdp != userToMaj.DoitChangerMdp)
                userToMaj.DoitChangerMdp = user.DoitChangerMdp;
            if (user.IsActif != userToMaj.IsActif)
                userToMaj.IsActif = user.IsActif;
            if (user.IsAdmin != userToMaj.IsAdmin)
                userToMaj.IsAdmin = user.IsAdmin;
            #endregion

            //Mise à jour
            bool result = _UtilisateurManager.MajUtilisateur(userToMaj);

            if(result)
                return "Mise à jour effectuée";
            else
                return "[Erreur]Une erreur est survenue lors de la mise à jour de l'utilisateur";


        }

        #endregion

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
        public List<Ref_Compte> GetListComptes()
        {
            return this._EpargneManager.GetListComptes();
        }

        //Ajout d'un compte
        public void AddCompte(string libelleCompte)
        {
            Ref_Compte cpt = new Ref_Compte();
            cpt.Compte = libelleCompte;
            cpt.Montant = 0;
            cpt.IsActif = true;

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
