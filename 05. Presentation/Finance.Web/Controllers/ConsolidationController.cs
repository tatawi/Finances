using Finance.Business.Interface.Services;
using Finance.Business.Services;
using Finance.Code.Enums;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ViewModels.Consolidation;
using ViewModels.Depenses;

namespace Finance.Controllers
{
    public class ConsolidationController : Controller
    {
        private IConsolidationService _ConsolidationService { get; set; }
        private IDepensesService _DepensesService { get; set; }

        public ConsolidationController()
        {
            this._ConsolidationService = new ConsolidationService();
            this._DepensesService = new DepensesService();
        }

        #region Mensuel
        //GET PAGE
        public ActionResult ConsoMensuelle()
        {
            ConsoMensuelleVM model = new ConsoMensuelleVM();
            DateTime laDate = DateTime.Now;

            model.Annee = laDate.Year;
            model.Mois = laDate.Month;
            model.list_mois = _ConsolidationService.GetListMois();
            ViewBag.Utilisateur = User.Identity.Name;

            return View(model);
        }

        // GET (AJAX) - Chargement tableau dépenses TOTAL
        public JsonResult CalculerDepensesConsolidesMois(int paramAnnee, int paramMois)
        {
            var result = new List<object>();
            List<ConsolidationVM> list_Conso = _ConsolidationService.GetListConsoMensuelle(paramAnnee, paramMois, true, User.Identity.Name, this.isComptePerso());
            //TempData["ListeDepensesMoisConsolidees"] = list_Conso;

            foreach (ConsolidationVM conso in list_Conso)
            {
                string type = "";

                //tab revenus
                if(conso.Cat==EnumCategorie.Revenus)
                {
                    type = "Revenus";
                    result.Add(new { type, conso.Libelle, conso.isCat, conso.Montant });
                }

                //tab Impots
                if (conso.Cat == EnumCategorie.Impots || conso.Cat == EnumCategorie.TOTALImpots)
                {
                    type = "Impots";
                    result.Add(new { type, conso.Libelle, conso.isCat, conso.Montant });
                }

                //tab Indispensable
                if (conso.Cat == EnumCategorie.Logement || conso.Cat == EnumCategorie.Alimentaire || conso.Cat == EnumCategorie.Emprunts)
                {
                    type = "Indispensable";
                    result.Add(new { type, conso.Libelle, conso.isCat, conso.Montant });
                }

                //tab Dispensable
                if (conso.Cat == EnumCategorie.Voiture || conso.Cat == EnumCategorie.Transport || conso.Cat == EnumCategorie.Loisirs || conso.Cat == EnumCategorie.Voyages)
                {
                    type = "Dispensable";
                    result.Add(new { type, conso.Libelle, conso.isCat, conso.Montant });
                }

                //tab Dispensable2
                if (conso.Cat == EnumCategorie.Cadeaux || conso.Cat == EnumCategorie.Achats || conso.Cat == EnumCategorie.Vetements
                    || conso.Cat == EnumCategorie.Sante || conso.Cat == EnumCategorie.FraisBancaires)
                {
                    type = "Dispensable2";
                    result.Add(new { type, conso.Libelle, conso.isCat, conso.Montant });
                }

            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //POST (AJAX) - Ajouter dépense Tableau
        public void AjouterDepenseTableauMensuel(AjouterDepenseUnitaireVM vm)
        {
            vm.user = User.Identity.Name;
            vm.compte = this.isComptePerso();
            _DepensesService.AjouterDepenseUnitaire(vm);
        }

        //POST (AJAX) - Calculer total
        public void CalculerTotaux()
        {
            int annee = Convert.ToInt16(Request.Params["paramAnnee"]);
            int mois = Convert.ToInt16(Request.Params["paramMois"]);

            string retour = _ConsolidationService.Calculer_TOTAUX(annee, mois, User.Identity.Name, this.isComptePerso());
            TempData["messageDupliquerVersComptesPerso"] = retour;
        }

        //GET (AJAX) - Récupérer le message de la duplication vers compte perso
        public JsonResult GetMessageCalculTotaux(string paramCat)
        {
            var result = new List<object>();
            string msg = "Echec du calcul";
            if (TempData["messageDupliquerVersComptesPerso"] != null)
                msg = TempData["messageDupliquerVersComptesPerso"].ToString();

            result.Add( new { msg });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //POST (AJAX) - Dupliquer les dpéenses communes vers perso
        public void DupliquerDepensesVersPerso(int paramAnnee, int paramMois)
        {
            _ConsolidationService.DupliquerDepensesVersPerso(paramAnnee, paramMois, User.Identity.Name);
        }

        #endregion


        #region Annuel
        //GET PAGE AJOUTER
        public ActionResult ConsoAnnuelle()
        {
            ConsoAnnuelleVM model = new ConsoAnnuelleVM();
            DateTime laDate = DateTime.Now;
            model.Annee = laDate.Year;
            return View(model);
        }

        // GET (AJAX) - Chargement tableau dépenses annuel TOTAL
        public JsonResult GetDepensesConsolidesAnnuel(int paramAnnee)
        {
            List<ConsolidationAnnuelleVM> list_Conso = _ConsolidationService.GetListConsoAnnuelle(paramAnnee, User.Identity.Name, this.isComptePerso());

            var result = new List<object>();
            foreach (ConsolidationAnnuelleVM conso in list_Conso)
            {
                result.Add(
                    new
                    {
                        conso.Libelle,
                        conso.isCat,
                        conso.MontantJanvier,
                        conso.MontantFevrier,
                        conso.MontantMars,
                        conso.MontantAvril,
                        conso.MontantMai,
                        conso.MontantJuin,
                        conso.MontantJuillet,
                        conso.MontantAout,
                        conso.MontantSeptembre,
                        conso.MontantOctobre,
                        conso.MontantNovembre,
                        conso.MontantDecembre
                    });
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion


        #region Général
        //GET PAGE AJOUTER
        public ActionResult ConsoGenerale()
        {
            ConsoGeneraleVM model = new ConsoGeneraleVM();
            model.User = User.Identity.Name;
            model.IsForperso = this.isComptePerso();
            model = _ConsolidationService.GET_RecapGeneral(model, false);
            return View(model);
        }

        #endregion


        #region Graphiques

        //GET PAGE Graphiques
        public ActionResult Graphiques()
        {
            return View();
        }

        #region Onglet - Graphs généraux
        //Get onglet Graphs généraux
        public ActionResult GraphGeneraux()
        {
            return PartialView("_GraphsGeneraux");
        }

        // GET (AJAX) - Tableau revenus
        public JsonResult GetGraphiqueRevenus()
        {
            int anneeDebut = 2013;
            int anneeCourante = DateTime.Now.Year ;
            var result = new List<object>();
            string user = User.Identity.Name;

            for (int Annee = anneeDebut; Annee <= anneeCourante; Annee++)
            {
                decimal Salaire = _ConsolidationService.GetMontantSsCatAnnee(Annee, EnumSousCategorie.Revenus_Salaire, user);
                decimal Entreprise = _ConsolidationService.GetMontantSsCatAnnee(Annee, EnumSousCategorie.Revenus_Entreprise, user);
                decimal Aides = _ConsolidationService.GetMontantSsCatAnnee(Annee, EnumSousCategorie.Revenus_Aides, user);
                decimal Interets = _ConsolidationService.GetMontantSsCatAnnee(Annee, EnumSousCategorie.Revenus_InteretsFi, user);
                decimal Vente = _ConsolidationService.GetMontantSsCatAnnee(Annee, EnumSousCategorie.Revenus_Vente, user);
                decimal Airbnb = _ConsolidationService.GetMontantSsCatAnnee(Annee, EnumSousCategorie.Revenus_Bnb, user);
                decimal Cadeaux = _ConsolidationService.GetMontantSsCatAnnee(Annee, EnumSousCategorie.Revenus_Cadeaux, user);

                result.Add( new { Annee, Salaire, Entreprise, Aides, Interets, Vente, Airbnb, Cadeaux });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET (AJAX) - Tableau solde
        public JsonResult GetGraphiqueSolde()
        {
            int anneeDebut = 2013;
            int anneeCourante = DateTime.Now.Year;
            var result = new List<object>();
            string user = User.Identity.Name;

            for (int Annee = anneeDebut; Annee <= anneeCourante; Annee++)
            {
                decimal mntRevenus = _ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Revenus, user);
                decimal mntDepenses = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.TOTALDepenses, user));
                decimal mntSolde = mntRevenus - mntDepenses;

                result.Add( new { Annee, mntRevenus, mntDepenses, mntSolde });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET (AJAX) - Tableau depenses
        public JsonResult GetGraphiqueDepenses()
        {
            int anneeDebut = 2013;
            int anneeCourante = DateTime.Now.Year;
            var result = new List<object>();
            string user = User.Identity.Name;

            for (int Annee = anneeDebut; Annee <= anneeCourante; Annee++)
            {
                decimal Logement = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Logement, user));
                decimal Alimentaire = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Alimentaire, user));
                decimal Voiture = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Voiture, user));
                decimal Transport = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Transport, user));
                decimal Loisirs = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Loisirs, user));
                decimal Voyage = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Voyages, user));
                decimal Cadeaux = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Cadeaux, user));
                decimal Achats = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Achats, user));
                decimal Vetements = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Vetements, user));
                decimal Sante = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Sante, user));
                decimal Impots = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Impots, user));
                decimal Frais = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.FraisBancaires, user));
                decimal Emprunt = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Emprunts, user));

                result.Add( new { Annee, Logement, Alimentaire, Voiture, Transport, Loisirs, Voyage,
                                  Cadeaux, Achats, Vetements, Sante, Impots, Frais, Emprunt });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET (AJAX) - Tableau depenses
        public JsonResult GetGraphiqueImpotsSalaire()
        {
            int anneeDebut = 2013;
            int anneeCourante = DateTime.Now.Year;
            var result = new List<object>();
            string user = User.Identity.Name;

            for (int Annee = anneeDebut; Annee <= anneeCourante; Annee++)
            {
                decimal Salaire = Math.Abs(_ConsolidationService.GetMontantSsCatAnnee(Annee, EnumSousCategorie.Revenus_Salaire, user));
                decimal Impots = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Impots, user));
                decimal ImpotsRev = Math.Abs(_ConsolidationService.GetMontantSsCatAnnee(Annee, EnumSousCategorie.Impots_Revenus, user));
                decimal Cotisations = Math.Abs(_ConsolidationService.GetMontantSsCatAnnee(Annee, EnumSousCategorie.Impots_Cotisations, user));

                result.Add( new { Annee, Salaire, Impots, ImpotsRev, Cotisations });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        #endregion


        #region Onglet - Graphs annuels
        //Get onglet Graphs annuels
        public ActionResult GraphAnnuels()
        {
            GraphiquesAnnuelsVM model = new GraphiquesAnnuelsVM();
            model.AnneeDebut = 2013;
            model.AnneeCourante = DateTime.Now.Year;
            model.nbAnnees = model.AnneeCourante - model.AnneeDebut;

            return PartialView("_GraphsAnnuels", model);
        }

        // GET (AJAX) - Pie Revenus
        public JsonResult GetGraphiqueRevenusPie(int Annee)
        {
            var result = new List<object>();
            string user = User.Identity.Name;

            decimal Salaire = _ConsolidationService.GetMontantSsCatAnnee(Annee, EnumSousCategorie.Revenus_Salaire, user);
            decimal Entreprise = _ConsolidationService.GetMontantSsCatAnnee(Annee, EnumSousCategorie.Revenus_Entreprise, user);
            decimal Aides = _ConsolidationService.GetMontantSsCatAnnee(Annee, EnumSousCategorie.Revenus_Aides, user);
            decimal Interets = _ConsolidationService.GetMontantSsCatAnnee(Annee, EnumSousCategorie.Revenus_InteretsFi, user);
            decimal Vente = _ConsolidationService.GetMontantSsCatAnnee(Annee, EnumSousCategorie.Revenus_Vente, user);
            decimal Airbnb = _ConsolidationService.GetMontantSsCatAnnee(Annee, EnumSousCategorie.Revenus_Bnb, user);
            decimal Cadeaux = _ConsolidationService.GetMontantSsCatAnnee(Annee, EnumSousCategorie.Revenus_Cadeaux, user);

            result.Add( new { Annee, Salaire, Entreprise, Aides, Interets, Vente, Airbnb, Cadeaux });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET (AJAX) - Pie depenses
        public JsonResult GetGraphiqueDepensesPie(int Annee)
        {
            var result = new List<object>();
            string user = User.Identity.Name;


            decimal Logement = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Logement, user));
            decimal Alimentaire = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Alimentaire, user));
            decimal Voiture = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Voiture, user));
            decimal Transport = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Transport, user));
            decimal Loisirs = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Loisirs, user));
            decimal Voyage = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Voyages, user));
            decimal Cadeaux = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Cadeaux, user));
            decimal Achats = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Achats, user));
            decimal Vetements = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Vetements, user));
            decimal Sante = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Sante, user));
            decimal Impots = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Impots, user));
            decimal Frais = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.FraisBancaires, user));
            decimal Emprunt = Math.Abs(_ConsolidationService.GetMontantCatAnnee(Annee, EnumCategorie.Emprunts, user));

            result.Add( new { Annee, Logement, Alimentaire, Voiture, Transport, Loisirs, Voyage, Cadeaux,
                              Achats, Vetements, Sante, Impots, Frais, Emprunt });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion


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