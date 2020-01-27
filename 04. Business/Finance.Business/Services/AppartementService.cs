using Finance.Business.Interface.Services;
using Finance.Business.Managers;
using Finance.Code.Enums;
using Finance.Data;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Services
{
    public class AppartementService : IAppartementService
    {
        private AppartementManager _AppartementManager { get; set; }

        public AppartementService()
        {
            _AppartementManager = new AppartementManager();
        }


        //Retourne une liste de valeurs de l'appartement pour toutes les années
        public List<int> GetListeValeurApptParAnnees()
        {
            int anneeDebut = 2013;
            int anneeCourante = DateTime.Now.Year;
            List<int> listeMontans = new List<int>();

            for (int annee = anneeDebut; annee <= anneeCourante; annee++)
            {
                int montantAnnee = _AppartementManager.GetListeValeurApptPourAnnee(annee);
                listeMontans.Add(montantAnnee);
            }

            //GetListeValeurApptPourAnnee
            return listeMontans;
        }

        //Retourne la valeur de l'appartement pour une année
        public int GetListeValeurApptPourAnnee(int annee)
        {
            return _AppartementManager.GetListeValeurApptPourAnnee(annee);
        }

        //Retourne la liste de toutes les valeurs
        public List<InfoAppartement> GetAllListValeursAppartement ()
        {
            return _AppartementManager.GetAllListValeursAppartement();
        }

        //Ajoute une nouvelle estimation
        public void AjouterEstimationAppartement(string source, decimal montant)
        {
            InfoAppartement estimation = new InfoAppartement();
            estimation.Montant = montant;
            estimation.Description = source;
            estimation.Type = EnumTypeInfoAppartement.ValeurAppartement;
            estimation.Date = DateTime.Now;
            _AppartementManager.AjouterEstimationAppartement(estimation);
        }


    }
}
