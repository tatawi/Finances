using Finance.Business.Interface.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Services
{
    public class MailService : IMailService
    {

        public MailService()
        {

        }


        public void EnvoyerMail(string to, string sujet, string corps)
        {
            //OsirisMailAdresseFrom
            SmtpClient client = new SmtpClient();
            
            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(ConfigurationManager.AppSettings["AdresseMailFrom"], to);
                mail.Subject = sujet;
                mail.Body = corps;
                mail.IsBodyHtml = true;

                client.Send(mail);
            }
            catch (Exception)
            {

            }
        }

        public void EnvoyerNouveauMotDePasse(string to, string mdp)
        {
            string sujet = "Osiris - Votre nouveau mot de passe";
            string corps = "<h2>Nouveau mot de passe</h2>";
            corps += "<br>";
            corps += "<br>Un nouveau mot de passe vient d'être généré pour votre comtpe sur l'application Gestion.";
            corps += "<br>Vous pouvez vous connecter avec les informations suivantes :";
            corps += "<br>Identifiant : " + to;
            corps += "<br>Mot de passe : " + mdp;

            this.EnvoyerMail(to, sujet, corps);
        }

        public void MailChangementMdp(string to)
        {
            string sujet = "Osiris - Modification de votre mot de passe";
            string corps = "Le mot de passe de l'application Gestion lié au compte " + to + " a été modifié le " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            corps += "<br><br>Si vous n'êtes pas à l'origine de ce changement, mercid e contacter un administrateur le plus tôt possible.";

            this.EnvoyerMail(to, sujet, corps);
        }
    }
}
