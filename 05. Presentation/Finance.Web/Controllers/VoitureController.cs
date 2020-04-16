using Finance.Business.Interface.Services;
using Finance.Business.Services;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels.Voiture;

namespace Finance.Controllers
{
    public class VoitureController : Controller
    {
        private IVoitureService _VoitureService { get; set; }


        public VoitureController()
        {
            this._VoitureService = new VoitureService();
        }



        // GET: Voiture
        public ActionResult MaVoiture()
        {
            return View();
        }




        #region Enregistrement 

        //Enregistrement plein d'essence
        public JsonResult EnregistrerPleinEssence(PleinEssence plein)
        {
            bool isEnregistrementOK = _VoitureService.EnregistrerPleinEssence(plein);
            return Json(isEnregistrementOK, JsonRequestBehavior.AllowGet);
        }

        //Enregistremnt entretien
        public JsonResult EnregistrerEntretien(EntretienVoiture entretien)
        {
            bool isEnregistrementOK = _VoitureService.EnregistrerEntretien(entretien);
            return Json(isEnregistrementOK, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region Onglet 1 - Infos générales

        //GET - Onglet 1 - Informations générales
        public ActionResult ChargementGeneral()
        {
            return PartialView("_General");
        }


        // GET (AJAX) - Get Dernier montant epargne
        public JsonResult GetDernierPlein()
        {
            var dernierPlein = _VoitureService.GetRecap();

            return Json(dernierPlein, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEntretiensPrevus()
        {
            var result = new List<object>();
            List<EntretienVoitureVM> liste = _VoitureService.GetEntretiensPrevus();
            return Json(liste, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInfosGeneralesParAnnees()
        {
            var result = new List<object>();
            List<PleinEssenceVM> liste = _VoitureService.GetKmEtConsoParAnnee();
            return Json(liste, JsonRequestBehavior.AllowGet);
        }


        #endregion




        #region Onglet 2 - Entretien

        //GET - Onglet 2 - Entretien
        public ActionResult ChargementEntretien()
        {
            return PartialView("_Entretien");
        }

        // GET (AJAX) - Get Entretien année
        public JsonResult GetEntretienAnnee(int annee)
        {
            var result = new List<object>();
            List<EntretienVoitureVM> liste = _VoitureService.GetEntretienForYear(annee);
            return Json(liste, JsonRequestBehavior.AllowGet);
        }

        // GET (AJAX) - Get Entretiens par années
        public JsonResult GetEntretiensParAnnee()
        {
            var result = new List<object>();
            List<EntretienVoitureVM> liste = _VoitureService.GetEntretiensParAnnees();
            return Json(liste, JsonRequestBehavior.AllowGet);
        }

        // GET (AJAX) - Get Entretiens par années
        public JsonResult GetEntretiensParType()
        {
            var result = new List<object>();
            List<EntretienVoitureVM> liste = _VoitureService.GetEntretiensParType();
            return Json(liste, JsonRequestBehavior.AllowGet);
        }

        #endregion




        #region Onglet 3 - Essence

        //GET - Onglet 3 - Essence
        public ActionResult ChargementEssence()
        {
            return PartialView("_Essence");
        }

        // GET (AJAX) - Get Pleins année
        public JsonResult GetPleinsEssenceAnnee(int annee)
        {
            var result = new List<object>();
            List<PleinEssenceVM> liste = _VoitureService.GetPleinsEssenceForYear(annee);
            return Json(liste, JsonRequestBehavior.AllowGet);
        }

        // GET (AJAX) - Get Pleins par années
        public JsonResult GetPleinsEssenceParAnnee()
        {
            var result = new List<object>();
            List<PleinEssenceVM> liste = _VoitureService.GetPleinsEssenceParAnnees();
            return Json(liste, JsonRequestBehavior.AllowGet);
        }

        #endregion



    }
}