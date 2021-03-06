﻿using Finance.ApodApi.Interface.Services;
using Finance.ApodApi.Interface.ViewModel;
using Finance.ApodApi.Services;
using Finance.Business.Interface.Services;
using Finance.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ViewModels.Login;

namespace Finance.Controllers
{
    
    public class LoginController : Controller
    {
        private ILoginService _LoginService { get; set; }
        private IApodApiService _ApodApiService { get; set; }

        public LoginController()
        {
            this._LoginService = new LoginService();
            this._ApodApiService = new ApodApiService();
        }


        //GET - page login
        [AllowAnonymous]
        public ActionResult Authent()
        {
            LoginVM viewModel = new LoginVM { Authentifie = HttpContext.User.Identity.IsAuthenticated };

            if (viewModel.Authentifie)
            {
                viewModel.Utilisateur = HttpContext.User.Identity.Name;
            }

            return View(viewModel);
        }


        //POST - page login
        [HttpPost]
        public ActionResult Authent(LoginVM vm)
        {
            if(vm.Utilisateur==null)
            {
                if(vm.newMdp==null && vm.newConfirmMdp==null)
                    vm.Message = _LoginService.ReinitialiserMdp(vm);
                else
                    vm.Message = _LoginService.CreerUtilisateur(vm);
                return View(vm);
            }

            if (_LoginService.IsAuthentifie(vm))
                FormsAuthentication.SetAuthCookie(vm.Utilisateur, false);
            else
            {
                vm.Message = "[Erreur]Impossible de se connecter";
                return View(vm);
            }
                

            return Redirect(@Url.Content("~/"));

        }


        //POST - déconnexion
        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return Redirect(@Url.Content("~/"));
        }


        //GET (AJAX) - Get image du jour
        public JsonResult GetImageDuJour()
        {
            ApodApiJsonGet result;

            if (Session["ImageDuJour"] != null)
            {
                //Récupération
                result = (ApodApiJsonGet)Session["ImageDuJour"];
            }
            else
            {
                //Get données
                result = _ApodApiService.GetImageDuJour();
                //Sauvegarde session
                Session["ImageDuJour"] = result;
            }

            //Affichage
            return Json(result, JsonRequestBehavior.AllowGet);
        }




    }


}