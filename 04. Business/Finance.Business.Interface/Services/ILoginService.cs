using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Login;

namespace Finance.Business.Interface.Services
{
    public interface ILoginService
    {

        /// <summary>Permet de savoir si un utilisateur est authentifié ou non</summary>
        /// <param name="vm">ViewModel contenant les informations de connexion</param>
        /// <returns>Vrai si authentifié</returns>
        bool IsAuthentifie(LoginVM vm);

        /// <summary>Permet de créer un nouvel utilisateur dans l'application</summary>
        /// <param name="vm">ViewModel contenant les informations de l'utilisateur à créer</param>
        /// <returns>Message de création (erreur ou succés)</returns>
        string CreerUtilisateur(LoginVM vm);


        /// <summary>Permet de réinitialiser le mot de passe de l'utilisateur</summary>
        /// <param name="vm">ViewModel contenant les informations de l'utilisateur</param>
        /// <returns>Message de réinitialisation (erreur ou succés)</returns>
        string ReinitialiserMdp(LoginVM vm);


    }
}
