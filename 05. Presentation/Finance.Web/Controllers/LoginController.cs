using Finance.Business.Interface.Services;
using Finance.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ViewModels.Login;

namespace Finance.Controllers
{
    
    public class LoginController : Controller
    {
        private ILoginService _LoginService { get; set; }

        public LoginController()
        {
            this._LoginService = new LoginService();
        }


        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            LoginVM viewModel = new LoginVM { Authentifie = HttpContext.User.Identity.IsAuthenticated };

            if (viewModel.Authentifie)
            {
                viewModel.Utilisateur = HttpContext.User.Identity.Name;
            }

            return View(viewModel);
        }



        [HttpPost]
        public ActionResult Index(LoginVM vm)
        {

            if(_LoginService.IsAuthentifie(vm))
                FormsAuthentication.SetAuthCookie(vm.Utilisateur, false);

            return Redirect(@Url.Content("~/"));

        }

        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return Redirect(@Url.Content("~/"));
        }


    }

    
}