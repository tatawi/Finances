using Finance.Business.Interface.Services;
using System;
using System.Text;
using ViewModels.Login;

namespace Finance.Business.Services
{
    public class LoginService : ILoginService
    {


        public LoginService()
        {

        }

        //Authentification
        public bool IsAuthentifie(LoginVM vm)
        {
            string password = Convert.ToBase64String(Encoding.UTF8.GetBytes(vm.mdp));

            if (vm.Utilisateur== "Maxime" && password == "MTQ1Mi5Qb3VldA==")
                return true;

            if (vm.Utilisateur == "Test" && password == "dGVzdA==")
                return true;

            return false;
        }

    }
}
