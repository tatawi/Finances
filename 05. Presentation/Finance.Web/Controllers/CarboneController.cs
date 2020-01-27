using Finance.Attributes;
using Finance.Business.Services;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels.Carbone;

namespace Finance.Controllers
{
    [ApplicationAuthorize]
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
            var listConso = _CarboneService.GetAllBilans().OrderBy(c=>c.Annee).ToList();
  
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

        //GET (AJAX) - Chargement du bilan carbone de l'anée
        public JsonResult GetBilanAnnee(int annee)
        {
            var result = new List<object>();
            BilanCarbone c = _CarboneService.GetBilan(annee);

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
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        #endregion 

        #region Onglet 3 - Ajout bilan carbone

        //GET - onglet ajout bilan carbone
        public ActionResult ChargementOngletAjout()
        {
            return PartialView("_C12ajout");
        }

        //GET (AJAX) - Get bilan carbone détaillé
        public JsonResult GetBilanCarboneDetaille(int annee)
        {
            var result = new List<object>();
            var bilan = _CarboneService.GetBilanDetaille(annee);

                result.Add(new
                {
                    bilan.Annee,
                    bilan.NbPersonnes,
                    bilan.Surface,
                    bilan.ConsoElectricite,
                    bilan.ConsoElectriciteVerte,
                    bilan.ConsoGaz,
                    bilan.ConsoFioul,
                    bilan.ConsoEau,
                    bilan.KmVoiture,
                    bilan.NbDansVoiture,
                    bilan.ConsoVoiture,
                    bilan.HeuresAvion,
                    bilan.KmTrain,
                    bilan.HeuresBus,
                    bilan.HeuresMetro,
                    bilan.ViandeBoeuf,
                    bilan.ViandePorc,
                    bilan.ViandeVolaille,
                    bilan.ViandePoisson,
                    bilan.LaitageFromage,
                    bilan.Laitages,
                    bilan.lait,
                    bilan.FruitsHorsSaison,
                    bilan.FruitsAvion,
                    bilan.FruitsSaison,
                    bilan.PlatsCuisines,
                    bilan.FeculentsPain,
                    bilan.FeculentsRiz,
                    bilan.BoissonAlcool,
                    bilan.BoissonSodas,
                    bilan.EauBouteille,
                    bilan.DechetsOrga,
                    bilan.DechetsPapiers,
                    bilan.DechetsPlastiques,
                    bilan.DechetsVerre,
                    bilan.DechetsMetal,
                    bilan.DechetsAutres,
                    bilan.BiensManufactures,
                    bilan.Vetements,
                    bilan.Electro,
                    bilan.Internet,
                    bilan.Ordinateur,
                    bilan.Smartphone,
                    bilan.AppPhoto,
                    bilan.Television,
                    bilan.BiensAutres,
                    bilan.FinanceClassique,
                    bilan.FinanceVerte,
                    bilan.ServicePublic
                });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // POST (AJAX) - Ajouter un bilan carbone
        public void SauvegardeBilanCarbone(BilanCarboneVM vm)
        {
            _CarboneService.AjouterBilanCarbone(vm);
        }

        // POST (AJAX) - Ajouter un bilan carbone détaillé
        public void SauvegardeBilanCarboneDetaille(BilanCarboneDetails bilan)
        {
            _CarboneService.AjouterBilanCarboneDetaille(bilan);
        }

        #endregion 




    }
}