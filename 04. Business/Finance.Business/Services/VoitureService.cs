using Finance.Business.Interface.Services;
using Finance.Business.Managers.Voiture;
using Finance.Helpers.Enums;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Voiture;

namespace Finance.Business.Services
{
    public class VoitureService : IVoitureService
    {
        private EntretienVoitureManager EntretienVoitureManager { get; set; }
        private PleinEssenceManager PleinEssenceManager { get; set; }

        public VoitureService()
        {
            this.EntretienVoitureManager = new EntretienVoitureManager();
            this.PleinEssenceManager = new PleinEssenceManager();
        }

        //Ajouter un plein d'essence
        public bool EnregistrerPleinEssence(PleinEssence plein)
        {
            try
            {
                PleinEssenceManager.Ajouter(plein);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Ajouter un entretien
        public bool EnregistrerEntretien(EntretienVoiture entretien)
        {
            try
            {
                EntretienVoitureManager.Ajouter(entretien);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Onglet 1 - Général
        #region Onglet 1 - Général

        //Retourne les informations du dernier plein effectué
        public PleinEssence GetRecap()
        {
            PleinEssence recap = new PleinEssence();

            //Kilométres
            PleinEssence dernierPlein =  PleinEssenceManager.GetLast();
            recap.Km = dernierPlein.Km;

            //consoMoyenne
            recap.Conso = PleinEssenceManager.GetConsommationMoyenne();

            return recap;
        }

        //Retourne les prochains entretiens
        public List<EntretienVoitureVM> GetEntretiensPrevus()
        {
            List<EntretienVoitureVM> listeVm = new List<EntretienVoitureVM>();
            List<EntretienVoiture> liste = EntretienVoitureManager.GetEntretiensSuivants();

            foreach (EntretienVoiture ent in liste)
            {
                EntretienVoitureVM vm = EntretienVoitureManager.EntretienToVm(ent);
                listeVm.Add(vm);
            }

            return listeVm;
        }


        public List<PleinEssenceVM> GetKmEtConsoParAnnee()
        {
            List<PleinEssenceVM> listeVm = new List<PleinEssenceVM>();
            List<PleinEssence> liste = PleinEssenceManager.GetAll();
            List<int> listeAnnees = liste.Select(p => p.Date.Year).Distinct().ToList();

            foreach (int annee in listeAnnees)
            {
                int kmMin = liste.Where(p => p.Date.Year == annee).Min(p => p.Km);
                int kmMax = liste.Where(p => p.Date.Year == annee).Max(p => p.Km);
                int kmParcouruAnnee = kmMax - kmMin;

                int litres = liste.Where(p => p.Date.Year == annee).Sum(p => p.Litres);
                decimal consoAnnee = 0;
                if(kmParcouruAnnee !=0)
                    consoAnnee = (decimal)(100 * litres) / (decimal)kmParcouruAnnee;

                listeVm.Add(new PleinEssenceVM {Annee = annee, Km = kmParcouruAnnee, Conso = consoAnnee });
            }
            return listeVm;
        }



        #endregion


        // Onglet 2 - Entretien
        #region Onglet 2 - Entretien

        //Récupération entretien par année
        public List<EntretienVoitureVM> GetEntretienForYear(int annee)
        {
            List<EntretienVoitureVM> listeVm = new List<EntretienVoitureVM>();
            List<EntretienVoiture> liste = EntretienVoitureManager.GetAllForYear(annee).OrderBy(p => p.Date).ToList();

            foreach (EntretienVoiture ent in liste)
            {
                EntretienVoitureVM vm = EntretienVoitureManager.EntretienToVm(ent);
                listeVm.Add(vm);
            }

            return listeVm;
        }

        //Récupération des entretiens par années
        public List<EntretienVoitureVM> GetEntretiensParAnnees()
        {
            List<EntretienVoitureVM> listeVm = new List<EntretienVoitureVM>();
            List<EntretienVoiture> liste = EntretienVoitureManager.GetAll();
            List<int> listeAnnees = liste.Select(p => p.Date.Value.Year).Distinct().ToList();

            foreach (int annee in listeAnnees)
            {
                EntretienVoitureVM entretien = new EntretienVoitureVM();
                entretien.Annee = annee;
                entretien.Cout = liste.Where(p => p.Date.Value.Year == annee).Sum(p => p.Cout);
                listeVm.Add(entretien);
            }
            return listeVm;
        }

        //Récupération des entretiens par années
        public List<EntretienVoitureVM> GetEntretiensParType()
        {
            List<EntretienVoitureVM> listeVm = new List<EntretienVoitureVM>();
            List<EntretienVoiture> liste = EntretienVoitureManager.GetAll();

            //Reparations
            listeVm.Add(new EntretienVoitureVM
            {
                Type = EnumTypeEntretien.Reparations,
                Cout = liste.Where(p => p.Type == EnumTypeEntretien.Reparations).Sum(p => p.Cout)
            });

            //Vidange
            listeVm.Add(new EntretienVoitureVM
            {
                Type = EnumTypeEntretien.Vidange,
                Cout = liste.Where(p => p.Type == EnumTypeEntretien.Vidange).Sum(p => p.Cout)
            });

            //Assurance
            listeVm.Add(new EntretienVoitureVM
            {
                Type = EnumTypeEntretien.Assurance,
                Cout = liste.Where(p => p.Type == EnumTypeEntretien.Assurance).Sum(p => p.Cout)
            });

            //Nettoyage
            listeVm.Add(new EntretienVoitureVM
            {
                Type = EnumTypeEntretien.Nettoyage,
                Cout = liste.Where(p => p.Type == EnumTypeEntretien.Nettoyage).Sum(p => p.Cout)
            });

            //Accéssoires
            listeVm.Add(new EntretienVoitureVM {
                Type=EnumTypeEntretien.Accessoires,
                Cout = liste.Where(p => p.Type == EnumTypeEntretien.Accessoires).Sum(p => p.Cout)
            });

            return listeVm;
        }

        #endregion


        // Onglet 3 - Essence
        #region Onglet 3 - Essence

        public List<PleinEssenceVM> GetPleinsEssenceForYear(int annee)
        {
            List<PleinEssenceVM> listeVm = new List<PleinEssenceVM>();
            List<PleinEssence> liste = PleinEssenceManager.GetAllForYear(annee).Where(p=>p.Prix!=0).OrderBy(p=>p.Date).ToList();

            foreach (PleinEssence pl in liste)
            {
                PleinEssenceVM vm = PleinEssenceManager.PleinEssenceToVm(pl);
                listeVm.Add(vm);
            }
            return listeVm;
        }

        public List<PleinEssenceVM> GetPleinsEssenceParAnnees()
        {
            List<PleinEssenceVM> listeVm = new List<PleinEssenceVM>();
            List<PleinEssence> liste = PleinEssenceManager.GetAll();
            List<int> listeAnnees = liste.Select(p => p.Date.Year).Distinct().ToList();

            foreach (int annee in listeAnnees)
            {
                PleinEssenceVM pleinAnnee = new PleinEssenceVM();
                pleinAnnee.Annee = annee;
                pleinAnnee.Prix = liste.Where(p => p.Date.Year == annee).Sum(p => p.Prix);
                pleinAnnee.Litres = liste.Where(p => p.Date.Year == annee).Sum(p => p.Litres);
                pleinAnnee.PrixLitre = pleinAnnee.Prix / pleinAnnee.Litres;
                listeVm.Add(pleinAnnee);
            }
            return listeVm;
        }


        #endregion
    }
}
