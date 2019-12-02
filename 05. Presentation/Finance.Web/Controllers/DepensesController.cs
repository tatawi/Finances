using Finance.Business.Interface.Services;
using Finance.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels.Depenses;

namespace Finance.Controllers
{
    public class DepensesController : Controller
    {
        private IDepensesService _DepensesService { get; set; }


        public DepensesController()
        {
            this._DepensesService = new DepensesService();
        }

        // GET: Depenses
        public ActionResult Index()
        {
            return View();
        }


        #region Ajout unitaire
        //GET - Page
        public ActionResult AjoutUnitaire()
        {
            AjouterDepenseUnitaireVM vm = new AjouterDepenseUnitaireVM();

            vm.Annee = DateTime.Now.Year;
            vm.Mois = DateTime.Now.Month;
            vm.list_mois = this._DepensesService.GetListMois();

            //pop-up
            vm.Date = DateTime.Now;
            vm.list_SsCat = new List<SelectListItem>();
            vm.list_SsCat.Add(new SelectListItem { Value = "choix", Text = "choix" });
            vm.SsCat = 0;

            return View(vm);
        }

        // GET (AJAX) - Chargement tableau dépenses
        public JsonResult GetDepensesMois(int paramAnnee, int paramMois, string paramCat)
        {
            List<Poco.Depense> list_Depense = new List<Poco.Depense>();

            if (paramCat.Equals("All"))
                list_Depense = _DepensesService.GetAllDepensesMois(paramAnnee, paramMois, User.Identity.Name, this.isComptePerso());
            else
                list_Depense = _DepensesService.GetAllDepensesMoisForCat(paramAnnee, paramMois, paramCat, User.Identity.Name, this.isComptePerso());

            var result = new List<object>();
            foreach (Poco.Depense dep in list_Depense)
            {
                string str_date = dep.Date.Value.ToShortDateString();
                result.Add(new
                    {
                        dep.DepenseId,
                        dep.Montant,
                        str_date,
                        dep.Libelle,
                        dep.Categorie,
                        dep.SousCategorie,
                        dep.Reconductible
                    });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //GET (AJAX) - Liste Sous-catégories
        public JsonResult GetSousCategorie(string paramCat)
        {
            var result = new List<object>();
            List<string> list_SousCat = _DepensesService.GetListSsCategoriesStringFromCategorie(paramCat);

            foreach (string ssCat in list_SousCat)
            {
                result.Add( new { ssCat });
            }

            if (list_SousCat.Count() == 0)
            {
                string ssCat = "Vide";
                result.Add( new { ssCat });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //POST (AJAX) - Ajouter dépense
        public void AjouterDepense(AjouterDepenseUnitaireVM vm)
        {
            vm.user = User.Identity.Name;
            vm.compte = this.isComptePerso();
            _DepensesService.AjouterDepenseUnitaire(vm);
        }

        //POST (AJAX)Supprimer une dépense
        public void DeleteDepense()
        {
            int paramId = Convert.ToInt16(Request.Params["paramId"]);
            if (paramId != 0)
            {
                _DepensesService.SupprimerDepense(paramId);
            }
        }

        //POST (AJAX) - Dupliquer dépenses vers perso
        public JsonResult DupliquerDepensesVersPerso()
        {
            int annee = Convert.ToInt16(Request.Params["paramAnnee"]);
            int mois = Convert.ToInt16(Request.Params["paramMois"]);
            string msg = _DepensesService.DupliquerDepensesCommunesVersPerso(annee, mois, User.Identity.Name);

            var result = new List<object>();
            result.Add( new { msg });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion





        #region Ajout en masse
        //GET - Page
        public ActionResult AjoutEnMasse()
        {
            AjouterDepensesMasseVM model = new AjouterDepensesMasseVM();
            return View(model);
        }

        //POST (AJAX) - Ajouter plusieurs dépense
        public void ImportationDonneesDepenses()
        {
            AjouterDepensesMasseVM vm = new AjouterDepensesMasseVM();
            vm.donneesImport = Convert.ToString(Request.Params["paramTexte"]);
            vm.user = User.Identity.Name;
            vm.compte = this.isComptePerso();

            vm = _DepensesService.TraiterDepensesEnMasse(vm);

            TempData["ListeDesDepensesEnAjout"] = vm.list_Depense;
            TempData["ListeDesDepensesAjoutees"] = vm.list_DepenseAjoutees;
            TempData["MessageErreurAjoutDepensesMasse"] = vm.message;
        }

        //Get Message Erreur Ajout dépenses en masse
        public JsonResult GetMessageImportationDonnees()
        {
            string message = "Données correctement traités";

            if (TempData["MessageErreurAjoutDepensesMasse"] != null)
                message = (string)TempData["MessageErreurAjoutDepensesMasse"];

            var result = new List<object>();
            result.Add( new { message });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //GET (AJAX) get tab dépenses
        public JsonResult GetDepensesAajouter()
        {
            List<Poco.Depense> list_Depense = new List<Poco.Depense>();

            if (TempData["ListeDesDepensesEnAjout"] != null)
                list_Depense = (List<Poco.Depense>)TempData["ListeDesDepensesEnAjout"];

            var result = new List<object>();
            foreach (Poco.Depense dep in list_Depense)
            {
                string str_date = dep.Date.Value.ToShortDateString();
                result.Add(
                    new
                    {
                        dep.Montant,
                        str_date,
                        dep.Libelle,
                        dep.Categorie,
                        dep.SousCategorie
                    });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //GET (AJAX) get tab dépenses traitées
        public JsonResult GetDepensesAajouterTraitees()
        {
            List<Poco.Depense> list_Depense = new List<Poco.Depense>();

            if (TempData["ListeDesDepensesAjoutees"] != null)
                list_Depense = (List<Poco.Depense>)TempData["ListeDesDepensesAjoutees"];

            var result = new List<object>();
            foreach (Poco.Depense dep in list_Depense)
            {
                string str_date = dep.Date.Value.ToShortDateString();
                result.Add(
                    new
                    {
                        dep.Montant,
                        str_date,
                        dep.Libelle,
                        dep.Categorie,
                        dep.SousCategorie
                    });
            }
            TempData["ListeDesDepensesAjoutees"] = list_Depense;

            return Json(result, JsonRequestBehavior.AllowGet);

        }


        //POST (AJAX) Ajouter dépenses traitées
        public void AjouterDespensesTraitees()
        {
            List<Poco.Depense> list_DepenseAutoCalcule = new List<Poco.Depense>();

            if (TempData["ListeDesDepensesAjoutees"] != null)
                list_DepenseAutoCalcule = (List<Poco.Depense>)TempData["ListeDesDepensesAjoutees"];

            _DepensesService.AjouterDepensesMasse(list_DepenseAutoCalcule, User.Identity.Name, this.isComptePerso());
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
    }


}