using Finance.Business.Interface.Services;
using Finance.Business.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Finance.Controllers
{
    [Authorize]
    public class AdministrationController : Controller
    {
        #region Variables

        private IAdministrationService _AdministrationService { get; set; }

        #endregion

        public AdministrationController()
        {
            this._AdministrationService = new AdministrationService();
        }







        #region Index


        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }


        #endregion


        #region CoorespondanceCategoriesDepenses

        // GET: CoorespondanceCategoriesDepenses
        public ActionResult CoorespondanceCategoriesDepenses()
        {
            return View();
        }


        //GET - AJAX - Get liste cat dépenses
        public JsonResult GetListeAllCatDep()
        {
            var result = new List<object>();
            var list_CatDepense = this._AdministrationService.GetAllCategoriesDepenses();
            
            foreach (var catDep in list_CatDepense)
            {
                string categorie = catDep.Categorie.Nom;
                string ssCategorie = catDep.SousCategorie.Nom;
                result.Add( new { catDep.Libelle, categorie, ssCategorie });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }



        //POST - AJAX - Ajouter correspondance
        public void AjouterCorrespondance()
        {
            string libelle = Convert.ToString(Request.Params["paramLib"]);
            string categorie = Convert.ToString(Request.Params["paramCat"]);
            string ssCategorie = Convert.ToString(Request.Params["paramSsCat"]);

            bool ajoutOk = this._AdministrationService.AjouterCategorieDepense(libelle, categorie, ssCategorie);

            if (ajoutOk)
                TempData["messageAjouter"] = "Texte ajouté";
            else
                TempData["messageAjouter"] = "Texte déjà présent";
        }


        //GET (AJAX) - Récupérer le message de la duplication vers compte perso
        public JsonResult GetMessage()
        {
            var result = new List<object>();
            string msg = "Erreur";
            if (TempData["messageAjouter"] != null)
                msg = TempData["messageAjouter"].ToString();
            
            result.Add( new { msg });

            return Json(result, JsonRequestBehavior.AllowGet);
        }




        #endregion


        #region Comtpes Epargne


        public ActionResult ComptesEpargne()
        {
            return View();
        }


        //GET - AJAX - Get liste cat dépenses
        public JsonResult GetListAllComptes()
        {
            var result = new List<object>();
            var list_Comptes = this._AdministrationService.GetListComptesForuser(User.Identity.Name);

            foreach (var cpt in list_Comptes)
            {
                result.Add(new { cpt.Ref_CompteId, cpt.Compte, cpt.IsActif });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }



        //POST - AJAX - Ajouter correspondance
        public void AjouterCompte()
        {
            try
            {
                string compte = Convert.ToString(Request.Params["paramCompte"]);
                this._AdministrationService.AddCompteForUser(compte, User.Identity.Name);
                TempData["messageAjouter"] = "Compte ajouté";
            }
            catch(Exception)
            {
                TempData["messageAjouter"] = "Erreur lors de l'ajout";
            }
            
        }

        //POST (AJAX)Supprimer une dépense
        public void DeleteCompte(int paramId)
        {
            this._AdministrationService.SupprimerComtpe(paramId);
        }

        #endregion






    }
}