using Finance.Business.Interface.Services;
using Finance.Business.Managers;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModels.Consolidation;

namespace Finance.Business.Services
{
    public class ConsolidationService : IConsolidationService
    {
        private DepensesManager _DepensesManager { get; set; }
        private CategoriesManager _CategoriesManager { get; set; }


        public ConsolidationService()
        {
            this._DepensesManager = new DepensesManager();
            this._CategoriesManager = new CategoriesManager();
        }

        #region Conso Mensuelle

        //Get liste consolidation mensuelle des catégories et sous catégories
        public List<ConsolidationVM> GetListConsoMensuelle(int annee, int mois, bool displaySsCat, string user, bool isForPerso)
        {
            List<ConsolidationVM> list_libelles = new List<ConsolidationVM>();
            List<Depense> list_Depense = _DepensesManager.GetAllDepensesMois(annee, mois, user, isForPerso);
            List<string>list_nomsCat = _CategoriesManager.GetAllListSsCategoriesString();

            foreach (string cat in list_nomsCat)
            {
                ConsolidationVM conso = new ConsolidationVM();
                conso.Libelle = cat;
                conso.isCat = true;
                conso.Cat = cat;
                conso.Montant = list_Depense.Where(d => d.Categorie.Equals(cat)).Sum(m => m.Montant).Value;
                list_libelles.Add(conso);

                if (displaySsCat)
                {
                    foreach (string ssCat in _CategoriesManager.GetListSsCategoriesStringFromCategorie(cat))
                    {
                        ConsolidationVM sousConso = new ConsolidationVM();
                        sousConso.Libelle = ssCat;
                        sousConso.isCat = false;
                        sousConso.Cat = cat;
                        sousConso.Montant = list_Depense.Where(d => d.SousCategorie.Equals(ssCat)).Sum(m => m.Montant).Value;
                        list_libelles.Add(sousConso);
                    }
                }
            }
            return list_libelles;
        }

        #endregion

        #region Conso Annuelle

        //Get liste consolidée des catégories pour une année
        public List<ConsolidationAnnuelleVM> GetListConsoAnnuelle(int annee, string user, bool isForPerso)
        {
            List<ConsolidationAnnuelleVM> list_Conso = new List<ConsolidationAnnuelleVM>();
            List<ConsolidationAnnuelleVM> list_ConsoTemp = new List<ConsolidationAnnuelleVM>();

            for (int mois = 1; mois < 13; mois++)
            {
                List<ConsolidationVM> list_ConsoMois = this.GetListConsoMensuelle(annee, mois, true, user, isForPerso);
                list_Conso.Clear();

                foreach (ConsolidationVM c in list_ConsoMois)
                {
                    ConsolidationAnnuelleVM conso;
                    switch (mois)
                    {
                        case 1:
                            conso = new ConsolidationAnnuelleVM();
                            conso.isCat = c.isCat;
                            conso.Libelle = c.Libelle;
                            conso.MontantJanvier = c.Montant;
                            list_Conso.Add(conso);
                            break;

                        case 2:
                            conso = list_ConsoTemp.FirstOrDefault(v => v.Libelle.Equals(c.Libelle));
                            conso.MontantFevrier = c.Montant;
                            list_Conso.Add(conso);

                            break;

                        case 3:
                            conso = list_ConsoTemp.FirstOrDefault(v => v.Libelle.Equals(c.Libelle));
                            conso.MontantMars = c.Montant;
                            list_Conso.Add(conso);
                            break;

                        case 4:
                            conso = list_ConsoTemp.FirstOrDefault(v => v.Libelle.Equals(c.Libelle));
                            conso.MontantAvril = c.Montant;
                            list_Conso.Add(conso);
                            break;

                        case 5:
                            conso = list_ConsoTemp.FirstOrDefault(v => v.Libelle.Equals(c.Libelle));
                            conso.MontantMai = c.Montant;
                            list_Conso.Add(conso);
                            break;

                        case 6:
                            conso = list_ConsoTemp.FirstOrDefault(v => v.Libelle.Equals(c.Libelle));
                            conso.MontantJuin = c.Montant;
                            list_Conso.Add(conso);
                            break;

                        case 7:
                            conso = list_ConsoTemp.FirstOrDefault(v => v.Libelle.Equals(c.Libelle));
                            conso.MontantJuillet = c.Montant;
                            list_Conso.Add(conso);
                            break;

                        case 8:
                            conso = list_ConsoTemp.FirstOrDefault(v => v.Libelle.Equals(c.Libelle));
                            conso.MontantAout = c.Montant;
                            list_Conso.Add(conso);
                            break;

                        case 9:
                            conso = list_ConsoTemp.FirstOrDefault(v => v.Libelle.Equals(c.Libelle));
                            conso.MontantSeptembre = c.Montant;
                            list_Conso.Add(conso);
                            break;

                        case 10:
                            conso = list_ConsoTemp.FirstOrDefault(v => v.Libelle.Equals(c.Libelle));
                            conso.MontantOctobre = c.Montant;
                            list_Conso.Add(conso);
                            break;

                        case 11:
                            conso = list_ConsoTemp.FirstOrDefault(v => v.Libelle.Equals(c.Libelle));
                            conso.MontantNovembre = c.Montant;
                            list_Conso.Add(conso);
                            break;

                        case 12:
                            conso = list_ConsoTemp.FirstOrDefault(v => v.Libelle.Equals(c.Libelle));
                            conso.MontantDecembre = c.Montant;
                            list_Conso.Add(conso);
                            break;
                    }
                }

                list_ConsoTemp.Clear();
                foreach (ConsolidationAnnuelleVM ca in list_Conso)
                {
                    list_ConsoTemp.Add(ca);
                }
            }
            return list_Conso;
        }

        #endregion


        #region Conso Générale

        //Fonction - créer les liste du VM
        public ConsoGeneraleVM GET_RecapGeneral(ConsoGeneraleVM vm, bool displaySsCat)
        {
            try
            {
                List<ConsolidationGeneraleVM> liste_recap = new List<ConsolidationGeneraleVM>();
                int anneeDebut = 2013;
                int anneeCourante = DateTime.Now.Year;
                vm.list_recaps = new List<ConsolidationGeneraleVM>();
                vm.list_recapsMoyenne = new List<ConsolidationGeneraleVM>();

                for (int annee = anneeDebut; annee <= anneeCourante; annee++)
                {
                    ConsolidationGeneraleVM recapAnnuel = new ConsolidationGeneraleVM();
                    recapAnnuel.Annee = annee;
                    recapAnnuel.list_Consos = new List<ConsolidationVM>();

                    ConsolidationGeneraleVM recapAnnuelMoyen = new ConsolidationGeneraleVM();
                    recapAnnuelMoyen.Annee = annee;
                    recapAnnuelMoyen.list_Consos = new List<ConsolidationVM>();

                    foreach (string cat in _CategoriesManager.GetAllListSsCategoriesString())
                    {
                        ConsolidationVM conso = new ConsolidationVM();
                        conso.Libelle = cat;
                        conso.Cat = cat;
                        conso.isCat = true;
                        conso.Montant = _DepensesManager.Get_MontantCatAnnee(annee, cat, vm.User, vm.IsForperso);
                        recapAnnuel.list_Consos.Add(conso);

                        #region Moyenne
                        ConsolidationVM consoM = new ConsolidationVM();
                        consoM.Libelle = cat;
                        consoM.Cat = cat;
                        consoM.isCat = true;
                        consoM.Montant = decimal.Round((conso.Montant / 12), 0);
                        recapAnnuelMoyen.list_Consos.Add(consoM);
                        #endregion


                        if (displaySsCat)
                        {
                            foreach (string ssCat in _CategoriesManager.GetListSsCategoriesStringFromCategorie(cat))
                            {
                                ConsolidationVM sousConso = new ConsolidationVM();
                                sousConso.Libelle = ssCat;
                                sousConso.isCat = false;
                                sousConso.Cat = cat;
                                sousConso.Montant = _DepensesManager.Get_MontantSsCatAnnee(annee, ssCat, vm.User, vm.IsForperso);
                                recapAnnuel.list_Consos.Add(sousConso);

                                #region Moyenne
                                ConsolidationVM sousConsoM = new ConsolidationVM();
                                sousConsoM.Libelle = ssCat;
                                sousConsoM.isCat = false;
                                sousConsoM.Cat = cat;
                                sousConsoM.Montant = decimal.Round((conso.Montant / 12), 0);
                                recapAnnuelMoyen.list_Consos.Add(sousConsoM);
                                #endregion
                            }
                        }
                    }
                    vm.list_recaps.Add(recapAnnuel);
                    vm.list_recapsMoyenne.Add(recapAnnuelMoyen);
                }
                return vm;
            }
            catch (Exception ex)
            {
                vm.list_recaps = new List<ConsolidationGeneraleVM>();
                vm.list_recapsMoyenne = new List<ConsolidationGeneraleVM>();
                vm.Message = ex.Message;
                return vm;
            }
        }

        #endregion


        #region Graphiques

        //Get montant sous-catégorie de l'année
        public decimal GetMontantSsCatAnnee(int annee, string ssCat, string user)
        {
            return _DepensesManager.Get_MontantSsCatAnnee(annee, ssCat, user, true);
        }

        //Get montant sous-catégorie de l'année
        public decimal GetMontantCatAnnee(int annee, string cat, string user)
        {
            return _DepensesManager.Get_MontantCatAnnee(annee, cat, user, true);
        }

        //Get montant catégorie du mois
        public decimal GetMontantCatMois(int annee, int mois, string cat, string user)
        {
            return _DepensesManager.Get_MontantCatMois(annee, mois, cat, user, true);
        }


        #endregion


        #region Fonctions
        //Get list des mois
        public List<SelectListItem> GetListMois()
        {
            var list_mois = new List<SelectListItem>();

            DateTime date = new DateTime();

            for (int i = 1; i < 13; i++)
            {
                date = new DateTime(2008, i, 1, 8, 30, 52);
                SelectListItem li = new SelectListItem { Text = date.ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture), Value = date.Month.ToString() };
                list_mois.Add(li);
            }
            return list_mois;
        }

        //Calcul les champs calculables pour un mois donné
        public string Calculer_TOTAUX(int annee, int mois, string user, bool isForPerso)
        {
            try
            {
                List<Depense> list_DepenseMois = new List<Depense>();
                list_DepenseMois = _DepensesManager.GetAllDepensesMois(annee, mois, user, isForPerso);

                _DepensesManager.Calculate_TotalImpotsFor(annee, mois, list_DepenseMois, user, isForPerso);
                decimal dep = _DepensesManager.Calculate_TotalDepensesFor(annee, mois, list_DepenseMois, user, isForPerso);
                _DepensesManager.Calculate_SoldeFor(annee, mois, list_DepenseMois, dep, user, isForPerso);

                return "Calcul des TOTAUX effectué";
            }
            catch (Exception ex)
            {
                return "Erreur de calcul : " + ex.Message;
            }
        }

        //Duplique les dépenses communes vers les dépenses persos
        public void DupliquerDepensesVersPerso(int paramAnnee, int paramMois, string user)
        {
            List<Depense> listDepensesCommunes = _DepensesManager.GetAllDepensesMois(paramAnnee, paramMois, user, false);

            foreach (Depense dep in listDepensesCommunes)
            {
                if (!_DepensesManager.IsDepensePresenteByDateAndLib(dep, user, true))
                {
                    dep.Libelle = "[Commun]" + dep.Libelle;
                    dep.Montant = dep.Montant / 2;
                    _DepensesManager.AjouterDepenseUnitaire(dep, user, true);
                }
            }
        }
        #endregion



    }
}
