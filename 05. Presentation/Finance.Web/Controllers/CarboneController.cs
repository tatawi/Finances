using Finance.Business.Services;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finance.Controllers
{
    public class CarboneController : Controller
    {
        private CarboneService _CarboneService { get; set; }

        public CarboneController()
        {
            this._CarboneService = new CarboneService();
        }

        // GET - PAGE PRINCIPALE
        public ActionResult Index()
        {
            return View();
        }


        #region Onglet 1 - Général

        //GET - onglet général
        public ActionResult ChargementOngletGeneral()
        {
            return PartialView("_C12general");
        }

        //GET (AJAX) - Chargement des bilans carbones
        public JsonResult GetDonneesBilans()
        {
            var result = new List<object>();
            var listConso = _CarboneService.GetAllBilans(User.Identity.Name);

            foreach (var c in listConso)
            {
                result.Add(new
                {
                    c.Annee,
                    c.Logement,
                    c.Transports,
                    c.Alimentation,
                    c.Dechets,
                    c.Achats,
                    c.Finance,
                    c.ServicePublique,
                    c.Total
                });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion 

        #region Onglet 2 - Bilan Carbone

        //GET - onglet bilan carbone
        public ActionResult ChargementOngletBilan()
        {
            return PartialView("_C12bilan");
        }



        #endregion 

        #region Onglet 3 - Ajout bilan carbone

        //GET - onglet ajout bilan carbone
        public ActionResult ChargementOngletAjout()
        {
            return PartialView("_C12ajout");
        }

        // POST (AJAX) - Ajouter un bilan carbone
        public void PostCBilanCarbone(BilanCarbone vm)
        {
            _CarboneService.AjouterBilanCarbone(vm, User.Identity.Name);
        }

        #endregion 




    }
}