using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Finance.Attributes;
using Finance.Business.Interface.Services;
using Finance.Business.Services;
using ViewModels.Consommation;


namespace Finance.Controllers
{
    [ApplicationAuthorize]
    public class AppartementController : Controller
    {
        private IAppartementService _AppartementService { get; set; }
        private IConsoEauService _ConsoEauService { get; set; }
        private IConsoElecService _ConsoElecService { get; set; }
        private IConsoEnergieService _ConsoEnergieService { get; set; }

        public AppartementController()
        {
            _AppartementService = new AppartementService();
            _ConsoEauService = new ConsoEauService();
            _ConsoElecService = new ConsoElecService();
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



        // GET (AJAX) - Chargement du tableau de consommation de chauffage de l'année
        //public JsonResult GetListConsoChauffageAnnee()
        //{
        //    bdd_Chauffage = new bdd_ConsoChauffage();

        //    List<ConsoChauffage> list_Conso = new List<ConsoChauffage>();
        //    List<ConsoChauffage> list_Date = bdd_Chauffage.get_ListConsoChauffageForYear(DateTime.Now.Year);
        //    ConsoChauffage consoPrecedente = new ConsoChauffage(); ;
        //    list_Date = list_Date.OrderBy(v => v.Date).ToList();

        //    for (int mois=1; mois <=12; mois++)
        //    {
        //        ConsoChauffage consoDate = list_Date.Where(d => d.Date.Value.Month == mois).OrderByDescending(d=>d.Date).FirstOrDefault();

        //        if (consoDate != null)
        //        {
        //            ConsoChauffage conso = consoDate.ShallowCopy();
        //            if (mois!=1)
        //            {
        //                conso.ConsoCuisine -= consoPrecedente.ConsoCuisine;
        //                conso.ConsoSalon -= consoPrecedente.ConsoSalon;
        //                conso.ConsoSalonTV -= consoPrecedente.ConsoSalonTV;
        //                conso.ConsoBureau -= consoPrecedente.ConsoBureau;
        //                conso.ConsoChambre -= consoPrecedente.ConsoChambre;
        //                conso.ConsoBnb -= consoPrecedente.ConsoBnb;
        //                conso.ConsoSdb -= consoPrecedente.ConsoSdb;
        //            }

        //            consoPrecedente = list_Date.Where(d => d.Date.Value.Month == mois).OrderByDescending(d => d.Date).FirstOrDefault();
        //            list_Conso.Add(conso);
        //        }
        //    }

        //    var result = new List<object>();
        //    foreach (ConsoChauffage info in list_Conso)
        //    {
        //        System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
        //        string Mois = mfi.GetMonthName(info.Date.Value.Month).ToString();

        //        result.Add(
        //            new
        //            {
        //                Mois,
        //                info.ConsoCuisine,
        //                info.ConsoSalon,
        //                info.ConsoSalonTV,
        //                info.ConsoBureau,
        //                info.ConsoChambre,
        //                info.ConsoBnb,
        //                info.ConsoSdb
        //            });
        //    }

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}



        // GET (AJAX) - Chargement du tableau de consommation de chauffage de l'année
        //public JsonResult GetListConsoChauffagePieAnnee(int Annee)
        //{
        //    bdd_Chauffage = new bdd_ConsoChauffage();

        //    List<ConsoChauffage> list_Conso = bdd_Chauffage.get_ListConsoChauffageForYear(Annee);
        //    ConsoChauffage conso = list_Conso.OrderByDescending(v => v.Date).FirstOrDefault();
           
        //    var result = new List<object>();
 
        //        result.Add(
        //            new
        //            {
        //                conso.ConsoCuisine,
        //                conso.ConsoSalon,
        //                conso.ConsoSalonTV,
        //                conso.ConsoBureau,
        //                conso.ConsoChambre,
        //                conso.ConsoBnb,
        //                conso.ConsoSdb
        //            });

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}


        // GET (AJAX) - Chargement du tableau de consommation de chauffage de l'année
        //public JsonResult GetListConsoChauffageTotal()
        //{
        //    bdd_Chauffage = new bdd_ConsoChauffage();
        //    List<ConsoChauffage> list_Recap = new List<ConsoChauffage>();
        //    List<ConsoChauffage> list_Conso = bdd_Chauffage.get_All();

        //    int currentYear = DateTime.Now.Year;
        //    int minYear = list_Conso.Min(d => d.Date).Value.Year;

        //    for (int annee = minYear; annee <= currentYear; annee++)
        //    {
        //        List<ConsoChauffage> list_ConsoAnnee = list_Conso.Where(d => d.Date.Value.Year == annee).ToList();
        //        ConsoChauffage conso = new ConsoChauffage();
        //        conso.Date = new DateTime(annee, 1, 1);
        //        conso.ConsoCuisine = list_ConsoAnnee.Max(v => v.ConsoCuisine).Value;
        //        conso.ConsoSalon = list_ConsoAnnee.Max(v => v.ConsoSalon).Value;
        //        conso.ConsoSalonTV = list_ConsoAnnee.Max(v => v.ConsoSalonTV).Value;
        //        conso.ConsoBureau = list_ConsoAnnee.Max(v => v.ConsoBureau).Value;
        //        conso.ConsoChambre = list_ConsoAnnee.Max(v => v.ConsoChambre).Value;
        //        conso.ConsoBnb = list_ConsoAnnee.Max(v => v.ConsoBnb).Value;
        //        conso.ConsoSdb = list_ConsoAnnee.Max(v => v.ConsoSdb).Value;
        //        conso.Montant = list_ConsoAnnee.Sum(v => v.Montant).Value;

        //        list_Recap.Add(conso);
        //    }

        //    var result = new List<object>();
        //    foreach (ConsoChauffage info in list_Recap)
        //    {
        //        int Annee = info.Date.Value.Year;

        //        result.Add(
        //            new
        //            {
        //                Annee,
        //                info.Montant,
        //                info.ConsoCuisine,
        //                info.ConsoSalon,
        //                info.ConsoSalonTV,
        //                info.ConsoBureau,
        //                info.ConsoChambre,
        //                info.ConsoBnb,
        //                info.ConsoSdb
        //            });
        //    }

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}





        // POST (AJAX) - Ajouter une consommation chauffage 
        //public void AjouteConsoChauffage()
        //{
        //    try
        //    {
        //        bdd_Chauffage = new bdd_ConsoChauffage();
        //        decimal montant = Convert.ToDecimal(Request.Params["paramMontant"]);
        //        string dateStr = Convert.ToString(Request.Params["paramDate"]);
        //        int ConsoCuisine = Convert.ToInt16(Request.Params["paramConsoCuisine"]);
        //        int ConsoSalon = Convert.ToInt16(Request.Params["paramConsoSalon"]);
        //        int ConsoSalonTV = Convert.ToInt16(Request.Params["paramConsoSalonTV"]);
        //        int ConsoBureau = Convert.ToInt16(Request.Params["paramConsoBureau"]);
        //        int ConsoChambre = Convert.ToInt16(Request.Params["paramConsoChambre"]);
        //        int ConsoBnb = Convert.ToInt16(Request.Params["paramConsoBnb"]);
        //        int ConsoSdb = Convert.ToInt16(Request.Params["paramConsoSdb"]);

        //        var dateStrTab = dateStr.Split('/');
        //        DateTime date;

        //        //gestion date
        //        if (dateStrTab.Length == 3)
        //        {
        //            date = new DateTime(int.Parse(dateStrTab[2]), int.Parse(dateStrTab[1]), int.Parse(dateStrTab[0]));
        //        }
        //        else
        //        {
        //            date = DateTime.Now;
        //        }

        //        ConsoChauffage conso = new ConsoChauffage();
        //        conso.Montant = montant;
        //        conso.Date = date;
        //        conso.ConsoCuisine = ConsoCuisine;
        //        conso.ConsoSalon = ConsoSalon;
        //        conso.ConsoSalonTV = ConsoSalonTV;
        //        conso.ConsoBureau = ConsoBureau;
        //        conso.ConsoChambre = ConsoChambre;
        //        conso.ConsoBnb = ConsoBnb;
        //        conso.ConsoSdb = ConsoSdb;

        //        bdd_Chauffage.Add_ConsoChauffage(conso);

        //        TempData["messageAjouter"] = "Consommation ajoutée";
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["messageAjouter"] = "Erreur lors de l'ajout : " + ex.Message;
        //    }
        //}

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