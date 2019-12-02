using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Finance.Code.Enums;
using Finance.Business.Interface.Services;
using Finance.Business.Services;
using ViewModels.Consolidation;

namespace Finance.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private IConsolidationService _ConsolidationService { get; set; }

        public HomeController()
        {
            this._ConsolidationService = new ConsolidationService();
        }


        #region Accueil

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetGraphiqueCurrentDepensesPie()
        {
            var result = new List<object>();
            string user = User.Identity.Name;
            int Annee = DateTime.Now.Year;
            int Mois = DateTime.Now.Month-1;
            if (Mois == 0) { Mois = 12; Annee--; }

            

            //si on a pas de données pour le mois courant, on prend le mois rpécédent
            decimal Logement = Math.Abs(_ConsolidationService.GetMontantCatMois(Annee, Mois, EnumCategorie.Logement, user));
            decimal Alimentaire = Math.Abs(_ConsolidationService.GetMontantCatMois(Annee, Mois, EnumCategorie.Alimentaire, user));
            decimal Voiture = Math.Abs(_ConsolidationService.GetMontantCatMois(Annee, Mois, EnumCategorie.Voiture, user));
            decimal Transport = Math.Abs(_ConsolidationService.GetMontantCatMois(Annee, Mois, EnumCategorie.Transport, user));
            decimal Loisirs = Math.Abs(_ConsolidationService.GetMontantCatMois(Annee, Mois, EnumCategorie.Loisirs, user));
            decimal Voyage = Math.Abs(_ConsolidationService.GetMontantCatMois(Annee, Mois, EnumCategorie.Voyages, user));
            decimal Cadeaux = Math.Abs(_ConsolidationService.GetMontantCatMois(Annee, Mois, EnumCategorie.Cadeaux, user));
            decimal Achats = Math.Abs(_ConsolidationService.GetMontantCatMois(Annee, Mois, EnumCategorie.Achats, user));
            decimal Vetements = Math.Abs(_ConsolidationService.GetMontantCatMois(Annee, Mois, EnumCategorie.Vetements, user));
            decimal Sante = Math.Abs(_ConsolidationService.GetMontantCatMois(Annee, Mois, EnumCategorie.Sante, user));
            decimal Impots = Math.Abs(_ConsolidationService.GetMontantCatMois(Annee, Mois, EnumCategorie.Impots, user));
            decimal Frais = Math.Abs(_ConsolidationService.GetMontantCatMois(Annee, Mois, EnumCategorie.FraisBancaires, user));
            decimal Emprunt = Math.Abs(_ConsolidationService.GetMontantCatMois(Annee, Mois, EnumCategorie.Emprunts, user));

            result.Add( new { Annee, Logement, Alimentaire, Voiture, Transport, Loisirs, Voyage, Cadeaux,
                              Achats, Vetements, Sante, Impots, Frais, Emprunt });

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