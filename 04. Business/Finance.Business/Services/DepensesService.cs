using Finance.Business.Interface.Services;
using Finance.Business.Managers;
using Finance.Code.Enums;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ViewModels.Depenses;

namespace Finance.Business.Services
{
    public class DepensesService : IDepensesService
    {
        private DepensesManager _DepensesManager { get; set; }
        private CategoriesManager _CategoriesManager { get; set; }

        private CategorieDepenseManager _CategorieDepenseManager { get; set; }

        public DepensesService()
        {
            this._DepensesManager = new DepensesManager();
            this._CategoriesManager = new CategoriesManager();
            this._CategorieDepenseManager = new CategorieDepenseManager();
        }

        //Retourne la liste des mois
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


        #region dépenses unitaires
        //Récupére la liste des dépenses du mois
        public List<Depense> GetAllDepensesMois(int annee, int mois, string user, bool isForPerso)
        {
            return _DepensesManager.GetAllDepensesMois(annee, mois, user, isForPerso);
        }

        //récupére la liste des dépenses du mois pour une catégorie
        public List<Depense> GetAllDepensesMoisForCat(int annee, int mois, string cat, string user, bool isForPerso)
        {
            return _DepensesManager.GetAllDepensesMois(annee, mois, user, isForPerso);
        }

        //Ajout d'une dépense
        public void AjouterDepenseUnitaire (AjouterDepenseUnitaireVM vm)
        {

            if (vm.strCategorie.Equals("Vide")) vm.strCategorie = "";

            if (vm.Libelle.Length < 1)
                vm.Libelle = vm.strCategorie + " " + vm.strSousCategorie + " " + vm.Date.DayOfWeek;

            if(vm.strDate!= null && vm.strDate!= "" && vm.strDate.Length>1)
            {
                var tbDdate = vm.strDate.Split('/');
                vm.Date = new DateTime(int.Parse(tbDdate[2]), int.Parse(tbDdate[1]), int.Parse(tbDdate[0]));
            }

            if(vm.MontantStr != null && vm.MontantStr != "")
            {
                vm.MontantStr = vm.MontantStr.Replace(".", ",");
                vm.Montant = decimal.Parse(vm.MontantStr);
            }

            Depense dep = new Depense()
            {
                Montant = vm.Montant,
                Date = vm.Date,
                Libelle = vm.Libelle,
                Categorie = vm.strCategorie,
                SousCategorie = vm.strSousCategorie,
                Reconductible = EnumReconductible.NonReconductible
            };

            //if(vm.strCatOuSsCat!="")
            //{
            //    dep = _DepensesManager.UpdateCatEtSsCatDepenseFromString(dep, vm.strCatOuSsCat);
            //    dep.Libelle = dep.Categorie + " " + dep.SousCategorie;
            //}

            _DepensesManager.AjouterDepenseUnitaire(dep, vm.user, vm.compte);
        }

        //Ajoute une liste de dépenses en base
        public void AjouterDepensesMasse(List<Depense> listDepenses, string user, bool isForPerso)
        {
            foreach (Depense dep in listDepenses)
            {
                _DepensesManager.AjouterDepenseUnitaire(dep, user, isForPerso);
            }
            
        }

        //Supprimer dépense
        public void SupprimerDepense(int depenseId)
        {
            _DepensesManager.SupprimerDepense(depenseId);
        }

        //Dupliquer dépenses vers perso
        public string DupliquerDepensesCommunesVersPerso(int annee, int mois, string user)
        {
            //bdd_Depense = new Bdd_Depense(User.Identity.Name, this.isComptePerso());
            List<Depense> list_DepenseCommunes = new List<Depense>();
            int nbTraites = 0;
            int nbDoublons = 0;


            list_DepenseCommunes = _DepensesManager.GetAllDepensesMois(annee, mois, user, false);
            int nbTotal = list_DepenseCommunes.Count;

            foreach (Depense dep in list_DepenseCommunes)
            {
                bool isDepensePresent = _DepensesManager.IsDepensePresente(dep, user, true);
                if (!isDepensePresent)
                {
                    Depense newDep = new Depense();
                    newDep.Categorie = dep.Categorie;
                    newDep.SousCategorie = dep.SousCategorie;
                    newDep.Date = dep.Date;
                    newDep.Libelle = "[Commun] " + dep.Libelle;
                    newDep.Reconductible = dep.Reconductible;
                    newDep.Montant = dep.Montant / 2;


                    _DepensesManager.AjouterDepenseUnitaire(newDep, user, true);
                    nbTraites++;
                }
                else
                {
                    nbDoublons++;
                }
            }

            //Gestion message
            if (nbTraites == 0)
            {
                return "Pas de nouvelles dépenses à ajouter";
            }

            else
            {
                if (nbDoublons > 0)
                    return "Ajout des dépenses communes [" + nbTraites + "/" + nbTotal + "] - " + nbDoublons + " doublons";
                else
                    return "Ajout des dépenses communes [" + nbTraites + "/" + nbTotal + "]";
            }
        }
        #endregion


        #region dépenses en masse

        //Traitement des données
        public AjouterDepensesMasseVM TraiterDepensesEnMasse (AjouterDepensesMasseVM vm)
        {

            vm.list_Depense = new List<Depense>();
            vm.list_DepenseAjoutees = new List<Depense>();
            vm.message = "Dépenses correctement traitées";
            bool depenseAdded = false;

            //Fortuneo Work
            int parcours = 0;
            string[] split = vm.donneesImport.Split(';');
            while (parcours < split.Length)
            {
                string val = "";
                try
                {
                    depenseAdded = false;
                    Depense dep = new Depense();
                    dep.Reconductible = "Non";

                    //Non prise en compte de la premiere date
                    parcours++;

                    //date
                    val = split[parcours];
                    string[] date = split[parcours].Split('/');
                    dep.Date = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));

                    //intitulé
                    parcours++;
                    val += " | " + split[parcours];
                    dep.Libelle = split[parcours];

                    //Montant
                    parcours++;
                    val += " | " + split[parcours];
                    var montant = split[parcours];
                    montant = montant.Replace(",", ".");
                    decimal result;
                    if (Decimal.TryParse(montant, out result))
                    {
                        // dep.Montant = System.Convert.ToDecimal(split[parcours]);
                        dep.Montant = result;
                    }
                    else if(Decimal.TryParse(split[parcours], out result))
                    {
                        dep.Montant = result;
                    }
                    else
                    {
                        dep.Montant = 0;
                    }
                    

                    if (!_DepensesManager.IsDepensePresenteByDateAndLib(dep,vm.user, vm.compte))
                    {
                        //Maj dépense
                        dep = this._CategorieDepenseManager.RenseignerCategoriesDepense(dep);

                        if (dep.Categorie != null)
                            vm.list_DepenseAjoutees.Add(dep);
                        else
                            vm.list_Depense.Add(dep);
                        depenseAdded = true;
                    }

                    //passage normalement vide
                    parcours++;
                    val += " | " + split[parcours];
                    if (split[parcours].Length < 5) parcours++;//passage dépense suivante
                    val += " | " + split[parcours];
                }
                catch (Exception ex)
                {
                    if (!depenseAdded)
                    {
                        if (vm.message.Contains("Dépenses")) vm.message = "";
                        vm.message += val + "<br>";
                    }
                    parcours++;
                }
            }
            return vm;
        }



        #endregion


        #region Categories

        //Get liste sous catégories
        public List<string> GetListSsCategoriesStringFromCategorie (string cat)
        {
            return _CategoriesManager.GetListSsCategoriesStringFromCategorie(cat);
        }

        #endregion

    }


}
