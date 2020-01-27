using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Finance.Code.Enums;
using Finance.Business.Interface.Services;
using Finance.Business.Services;
using ViewModels.Consolidation;
using Finance.ApodApi.Interface.ViewModel;
using Finance.ApodApi.Interface.Services;
using Finance.ApodApi.Services;
using Finance.Attributes;

namespace Finance.Controllers
{
    [ApplicationAuthorize]
    public class HomeController : Controller
    {

        private IConsolidationService _ConsolidationService { get; set; }
        private IApodApiService _ApodApiService { get; set; }

        public HomeController()
        {
            this._ConsolidationService = new ConsolidationService();
            this._ApodApiService = new ApodApiService();
        }


        #region Accueil

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetImageDuJour()
        {
            ApodApiJsonGet result = new ApodApiJsonGet();

            if (Session["HomeApod"] != null)
            {
                result = (ApodApiJsonGet)Session["HomeApod"];
            }
            else
            {
                //Get données
                result = _ApodApiService.GetImageDuJour();
                Session["HomeApod"] = result;
            }
            

            //Affichage
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        #endregion


        #region AJAX

        //GET => Get compte AJAX
        public JsonResult GetCompteAjax()
        {
            List<ConsolidationVM> list_Conso = new List<ConsolidationVM>();
            ConsolidationVM ca = new ConsolidationVM();
            ca.isCat = isComptePerso();
            list_Conso.Add(ca);

            var result = new List<object>();
            foreach (ConsolidationVM conso in list_Conso)
            {
                result.Add( new { conso.isCat, });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //POST => Set compte AJAX
        public void ChangementCompteAjax()
        {
            string compte = Convert.ToString(Request.Params["paramCompte"]);

            if (compte.Equals("perso"))
            {
                Session.Add("ComptePerso", true);
            }
            else
            {
                Session.Add("ComptePerso", false);
            }
        }

        

        #endregion


        #region Fonctions

        //Retourne true si on utilise le compte perso en Session
        private bool isComptePerso()
        {
            bool comptePerso = false;
            try
            {
                comptePerso = (bool)Session["ComptePerso"];
            }
            catch
            {
                Session.Add("ComptePerso", true);
                return true;

            }
            return comptePerso;

        }


        #endregion


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}