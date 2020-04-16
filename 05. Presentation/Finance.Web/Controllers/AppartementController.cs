using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Finance.Attributes;
using Finance.Business.Interface.Services;
using Finance.Business.Interface.Services.Consommations;
using Finance.Business.Services;
using Finance.Business.Services.Consommations;
using ViewModels.Consommation;


namespace Finance.Controllers
{
    [ApplicationAuthorize]
    public class AppartementController : Controller
    {
        private IAppartementService _AppartementService { get; set; }
        private IConsoEauService _ConsoEauService { get; set; }
        private IConsoElecService _ConsoElecService { get; set; }
        private IConsoChauffageService _ConsoChauffageService { get; set; }
        private IConsoEnergieService _ConsoEnergieService { get; set; }

        public AppartementController()
        {
            _AppartementService = new AppartementService();
            _ConsoEauService = new ConsoEauService();
            _ConsoElecService = new ConsoElecService();
            _ConsoChauffageService = new ConsoChauffageService();
            _ConsoEnergieService = new ConsoEnergieService();
        }

        //Page principale
        public ActionResult index()
        {
            return View();
        }

        #region Onglet 1 - Infos générales

        //GET - Onglet 1 - Informations générales
        public ActionResult ChargementInfosGenerales()
        {
            return PartialView("_InfosGenerales");
        }

        #endregion


        #region Onglet 2 - Valeur Appartement

        //Get - Onglet 2 - Valeur Appartement
        public ActionResult ChargementValeurAppartement()
        {
            return PartialView("_Valeur");
        }

        // GET (AJAX) - Chargement du tableau de valeur de l'appartement
        public JsonResult GetListValeursAppartement()
        {
            var list_Conso = _AppartementService.GetAllListValeursAppartement();
            var result = new List<object>();
            foreach (var info in list_Conso)
            {
                string Date = info.Date.Value.Year + "-" + info.Date.Value.Month + "-" + info.Date.Value.Day;
                string DateStr = info.Date.Value.Year + "-" + info.Date.Value.Month;
                string Montant = string.Format("{0:#,0.#}", info.Montant) + " €";
                decimal MontantVal = info.Montant.Value;
                result.Add(
                    new
                    {
                        Montant,
                        MontantVal,
                        Date,
                        DateStr,
                        info.Description
                    });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // POST (AJAX) - Ajouter une estimation 
        public void AjouterEstimation()
        {
            try
            {
                decimal montant = Convert.ToDecimal(Request.Params["paramMontant"]);
                string source = Convert.ToString(Request.Params["paramSource"]);

                _AppartementService.AjouterEstimationAppartement(source, montant);

                TempData["messageAjouter"] = "Ajout effectué";
            }
            catch (Exception ex)
            {
                TempData["messageAjouter"] = "Erreur lors de l'ajout : " + ex.Message;
            }
        }

        #endregion


        #region Onglet 3 - Consommation d'énergie

        //GET
        public ActionResult ChargementConsoEnergie()
        {
            return PartialView("_ConsoEnergie");
        }

        //GET (AJAX) - Chargement de toutes les consommations d'eau
        public JsonResult GetDonneesConsoEnergie()
        {
            var result = new List<object>();
            var listConso = _ConsoEnergieService.GetConsoEnergie();

            foreach (var c in listConso)
            {
                result.Add(new
                {
                    c.Annee,
                    c.ConsoChauffage,
                    c.ConsoEau,
                    c.ConsoElec,
                    c.ConsoTotale
                });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        #endregion


        #region Onglet 4 - Consommation Electricite

        //GET
        public ActionResult ChargementConsoElec()
        {
            return PartialView("_ConsoElec");
        }

        //GET (AJAX) - Chargement de toutes les consommations d'eau
        public JsonResult GetDonneesConsoElec()
        {
            var result = new List<object>();
            var listConso = _ConsoElecService.GetAllConsosElec();

            foreach (var c in listConso)
            {
                result.Add(new
                {
                    c.Annee,
                    c.Consommation,
                    c.Montant
                });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //GET (AJAX) - Liste des consommations de l'année
        public JsonResult GetDonneesConsoElecAnnee(int annee)
        {
            var result = new List<object>();
            var conso = _ConsoElecService.GetConsoElecAnnee(annee);

            foreach (var c in conso.listeConsoMois)
            {
                result.Add(new
                {
                    c.Mois,
                    c.MoisStr,
                    c.Montant,
                    c.Consommation
                });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        // POST (AJAX) - Ajouter une consommation d'eau 
        public void PostConsommationElec(_ConsoElec_POST vm)
        {
            bool success = false;
            if (vm.Annee != 0)
                success = _ConsoElecService.PostConsommationAnnee(vm);

            if (success)
                TempData["messageAjoutConsoEau"] = "Ajout effectué";
            else
                TempData["messageAjoutConsoEau"] = "Erreur lors de l'ajout : ";
        }
        

        #endregion


        #region Onglet 5 - Consommatione Eau

        //Get - Onglet 4 - Consommation eau
        public ActionResult ChargementConsoEau()
        {
            return PartialView("_ConsoEau");
        }

        //GET (AJAX) - Chargement de toutes les consommations d'eau
        public JsonResult GetDonneesConsoEau()
        {
            var result = new List<object>();
            var listConso = _ConsoEauService.GetConsommationEau();

            foreach (var c in listConso)
            {
                result.Add(new
                {
                    c.Annee,
                    c.ConsoCuisineChaud, c.MontantCuisineChaud,
                    c.ConsoCuisineFroid, c.MontantCuisineFroid,
                    c.ConsoSdbChaud, c.MontantSdbChaud,
                    c.ConsoSdbFroid, c.MontantSdbFroid,
                    c.ConsoWcFroid, c.MontantWcFroid,
                    c.ConsoTOTAL, c.MontantTOTAL
                    
                });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //GET (AJAX) - Chargement de la consommation d'eau d'une année
        public JsonResult GetDonneesConsoEauAnnee(int annee)
        {
            var result = new List<object>();
            var c = _ConsoEauService.GetConsommationEauAnnee(annee);

            result.Add(new
            {
                    c.Annee,
                    c.ConsoCuisineChaud,
                    c.MontantCuisineChaud,
                    c.ConsoCuisineFroid,
                    c.MontantCuisineFroid,
                    c.ConsoSdbChaud,
                    c.MontantSdbChaud,
                    c.ConsoSdbFroid,
                    c.MontantSdbFroid,
                    c.ConsoWcFroid,
                    c.MontantWcFroid
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // POST (AJAX) - Ajouter une consommation d'eau 
        public void PostConsommationEau(ConsommationEauAnnuelleVM vm)
        {
            bool success = false;
            if (vm.Annee!=0)
                success = _ConsoEauService.PostConsommationAnnee(vm);

            if (success)
                TempData["messageAjoutConsoEau"] = "Ajout effectué";
            else
                TempData["messageAjoutConsoEau"] = "Erreur lors de l'ajout : ";
        }

        #endregion


        #region Onglet 6 - Consommation Chauffage

        public ActionResult ChargementChauffage()
        {
            return PartialView("_ConsoChauffage");
        }

        //GET (AJAX) - Chargement de toutes les consommations d'eau
        public JsonResult GetDonneesConsoChauffageGeneral()
        {
            var listConso = _ConsoChauffageService.GetAllConsosChauffageGenerales();
            
            return Json(listConso, JsonRequestBehavior.AllowGet);
        }


        #endregion



        //GET (AJAX) - Récupérer le message de la duplication vers compte perso
        public JsonResult GetMessageAjout()
        {
            string msg = "";
            if (TempData["messageAjouter"] != null)
            {
                msg = TempData["messageAjouter"].ToString();
            }

            var result = new List<object>();
            result.Add(new{ msg});

            return Json(result, JsonRequestBehavior.AllowGet);
        }





    }
}