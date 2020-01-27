using Finance.Business.Interface.Services;
using Finance.Business.Managers;
using Finance.Poco;
using System;
using System.Text;
using ViewModels.Login;

namespace Finance.Business.Services
{
    public class LoginService : ILoginService
    {
        private UtilisateurManager utilisateurManager;

        private MailService mailService;

        public LoginService()
        {
            this.utilisateurManager = new UtilisateurManager();
            this.mailService = new MailService();
        }

        //Authentification sur le site
        public bool IsAuthentifie(LoginVM vm)
        {
            Utilisateur user = this.utilisateurManager.GetUtilisateur(vm.Utilisateur);

            if (user == null || !user.IsActif)
                return false;

            if (user.MotDePasse == this.utilisateurManager.Encrypt(vm.mdp))
            {
                ApplicationManager.SetupUser(vm.Utilisateur);
                return true;
            }
            return false;
        }

        //Création d'un utilisateur
        public string CreerUtilisateur(LoginVM vm)
        {
            if(!this.IsVerificationUtilisateurOk(vm))
            {
                return "[Erreur]L'utilisateur ne respecte pas les critéres requis";
            }

            Utilisateur newUser = new Utilisateur();
            newUser.Prenom = vm.newPrenom;
            newUser.Nom = vm.newNom;
            newUser.Email = vm.newMail;
            newUser.MotDePasse = this.utilisateurManager.Encrypt(vm.newMdp);

            try
            {
                bool result = this.utilisateurManager.AddUtilisateur(newUser);

                if(result)
                {
                    return "L'utilisateur a été créé. Il devra être activé par un administrateur.";
                }
                else
                {
                    return "[Erreur]Un utilisateur avec la même adresse mail existe déjà";
                }
            }
            catch (Exception ex)
            {
                return "[Erreur]"+ ex.Message;
            }

        }

        //Réinitialisation du mot de passe
        public string ReinitialiserMdp(LoginVM vm)
        {
            if(this.utilisateurManager.IsUtilisateurPresent(vm.newMail))
            {
                //Maj mot de passe
                Utilisateur user = this.utilisateurManager.GetUtilisateur(vm.newMail);
                string nouveauMdp = this.utilisateurManager.GenererMotDePasse();
                user.MotDePasse = this.utilisateurManager.Encrypt(nouveauMdp);
                user.DoitChangerMdp = true;

                //Sauvegarde en base
                if (!this.utilisateurManager.MajUtilisateur(user))
                    return "[Erreur]Une erreur est survenue lors de l'opération";

                //Envoie du mail
                mailService.EnvoyerNouveauMotDePasse(vm.newMail, nouveauMdp);
                nouveauMdp = "";

                return "Un mail a été envoyé avec les indications pour changer votre mot de passe.";
            }
            else
            {
                return "Un mail a été envoyé avec les indications pour changer votre mot de passe.";
            }

            
        }



        //Vérifie si l'utilisateur à créer est correct
        private bool IsVerificationUtilisateurOk(LoginVM vm)
        {
            if (!utilisateurManager.IsMotDePasseConforme(vm.newMdp))
                return false;


            return true;
        }

        





    }
}
