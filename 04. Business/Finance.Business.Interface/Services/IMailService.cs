using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Interface.Services
{
    public interface IMailService
    {
        /// <summary>Envoie d'un mail</summary>
        /// <param name="to">Adresse mail de destination</param>
        /// <param name="sujet">Sujet du mail</param>
        /// <param name="corps">Contenue du mail au format html</param>
        void EnvoyerMail(string to, string sujet, string corps);

        /// <summary>Envoie d'un mail de réinitialisation du mot de passe</summary>
        /// <param name="to">Adresse mail de destination</param>
        /// <param name="mdp">Nouveau mot de passe</param>
        void EnvoyerNouveauMotDePasse(string to, string mdp);

        /// <summary>Envoie un message informatif de changement de mot de passe</summary>
        /// <param name="to">Adresse mail de destination</param>
        void MailChangementMdp(string to);
    }
}
