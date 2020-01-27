using Finance.Attributes;
using Finance.Business.Interface.Services;
using Finance.Business.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ViewModels.Epargne;

namespace Finance.Controllers
{

    [ApplicationAuthorize]
    public class EpargneController : Controller
    {
        private IEpargneService _EpargneService { get; set; }
        private IAppartementService _AppartementService { get; set; }

        public EpargneController()
        {
            _EpargneService = new EpargneService();
            _AppartementService = new AppartementService();
        }


        // GET: Epargne
        public ActionResult Epargne()
        {
            return View();
        }


        // GET: Epargne page principale
        public ActionResult index()
        {
            return View();
        }

        // GET (AJAX) - Get montant par comptes
        public JsonResult GetLastMontantEpargne()
        {
            var result = new List<object>();
            var listComptes = _EpargneService.GetDernierMontantComptes();
            
            foreach (var cpt in listComptes)
            {
                result.Add(new { cpt.CompteId, cpt.Compte.Compte, cpt.Montant });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //POST (AJAX) - Sauvegarde en base de l'épargne
        public void SauvegarderMontantEpargne()
        {
            string jsonActions = Request.Params["ListeComptes"];
            string date = Request.Params["Date"];

            MontantsComptesVM ListeComptes = JsonConvert.DeserializeObject<MontantsComptesVM>(jsonActions);
            ListeComptes.Date = Convert.ToDateTime(date);

            _EpargneService.SauvegarderEpargne(ListeComptes);

        }



        #region Onglet 1 - Epargne par années

        //GET - Onglet 1 - Epargne par années
        public ActionResult ChargementEpAnnuelle()
        {
            return PartialView("_EpargneAnnuelle");
        }

        // GET (AJAX) - Chargement de l'epargne de l'année
        public JsonResult GetMontantEpargneAnnee(int Annee)
        {
            //List<Epargne> list_epargne = getEpargneparMois(Annee);
            var list_epargne = _EpargneService.GetEpargneparMois(Annee);

            var result = new List<object>();
            foreach (var info in list_epargne)
            {
                System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                string Mois = mfi.GetMonthName(info.Date.Value.Month).ToString();
                result.Add(new { Mois, info.Montant });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region Onglet 2 - Evolution de l'épargne

        //GET - Onglet 2 - Evolution de l'épargne
        public ActionResult ChargementEpToutesAnnees()
        {
            return PartialView("_EpargneToutesAnnees");
        }


        // GET (AJAX) - Chargement de toutes les epargnes
        public JsonResult GetMontantEpargneAllYears()
        {
            int anneeDebut = 2013;
            int anneeCourante = DateTime.Now.Year;
            var result = new List<object>();

            for (int annee = anneeDebut; annee <= anneeCourante; annee++)
            {
                var list_epargne = _EpargneService.GetEpargneparMois(annee);
                int Montant = list_epargne.Sum(m => m.Montant).Value;
                String AnneeStr = annee.ToString();
                result.Add(new { AnneeStr, Montant });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region Onglet 3 - Evolution montant épargne

        //GET - Onglet 3 - Evolution montant épargne
        public ActionResult ChargementEpTotale()
        {
            return PartialView("_EpargneTotale");
        }


        // GET (AJAX) - Chargement de toutes les epargnes
        public JsonResult GetMontantEpargneTotal()
        {
            int anneeDebut = 2013;
            int anneeCourante = DateTime.Now.Year;
            var result = new List<object>();

            for (int annee = anneeDebut; annee <= anneeCourante; annee++)
            {
                String AnneeStr = annee.ToString();

                //Epargne
                var list_epargne = _EpargneService.GetEpargneTotaleAnnee(annee);
                int MontantTotalEpargne = list_epargne.Sum(e => e.Montant).Value;

                //Appt
                int MontantAppartement = _AppartementService.GetListeValeurApptPourAnnee(annee);

                //Total
                int Total = MontantTotalEpargne + MontantAppartement;

                result.Add(new { AnneeStr, MontantTotalEpargne, MontantAppartement, Total });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region Onglet 4 - Montant épargne

        //GET - Onglet 4 - Montant épargne
        public ActionResult ChargementComptes()
        {
            return PartialView("_EpargneTotale");
        }


        #endregion




       


        


        


    }
}