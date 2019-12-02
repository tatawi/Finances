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
    }
}
