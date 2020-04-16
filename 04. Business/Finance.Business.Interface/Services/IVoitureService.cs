using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Voiture;

namespace Finance.Business.Interface.Services
{
    /// <summary>Accés aux fonctionnalités du module Voiture</summary>
    public interface IVoitureService
    {
        //--------------------------------------------------------------------------------------------------------------------------------------
        //Ajouts

        /// <summary>Enregistre un plein d'essence en base</summary>
        /// <param name="plein">Plein d'essence à enregistrer au format <PleinEssence/></param>
        /// <returns>Booléen selon le succés de l'enregistrement</returns>
        bool EnregistrerPleinEssence(PleinEssence plein);

        /// <summary>Enregistre un entretien en base</summary>
        /// <param name="entretien">Entretien à enregistrer au format <EntretienVoiture/></param>
        /// <returns>Booléen selon le succés de l'enregistrement</returns>
        bool EnregistrerEntretien(EntretienVoiture entretien);

        //--------------------------------------------------------------------------------------------------------------------------------------
        //Onglet 1

        /// <summary>Retourne le dernier plein d'essence en base</summary>
        /// <returns>Plein d'essence au format <PleinEssence/></returns>
        PleinEssence GetRecap();


        List<EntretienVoitureVM> GetEntretiensPrevus();

        List<PleinEssenceVM> GetKmEtConsoParAnnee();



        //--------------------------------------------------------------------------------------------------------------------------------------
        //Onglet 2

        /// <summary>Retourne les entretiens pour une année</summary>
        /// <param name="annee">Année concernée</param>
        /// <returns>Liste des entretiens de l'année au format <EntretienVoiture/></returns>
        List<EntretienVoitureVM> GetEntretienForYear(int annee);

        /// <summary>Retourne la somme du coût des entretiens par année</summary>
        /// <returns>Liste des sommes du coût des entretiens par année au format <EntretienVoitureVM/></returns>
        List<EntretienVoitureVM> GetEntretiensParAnnees();

        /// <summary>Retourne la somme du coût des entretiens par type</summary>
        /// <returns>Liste des sommes du coût des entretiens par type au format <EntretienVoitureVM/></returns>
        List<EntretienVoitureVM> GetEntretiensParType();


        //--------------------------------------------------------------------------------------------------------------------------------------
        //Onglet 3

        /// <summary>Retourne les pleins d'essence pour une année</summary>
        /// <param name="annee">Année concernée</param>
        /// <returns>Liste des pleins de l'année au format <PleinEssenceVM/></returns>
        List<PleinEssenceVM> GetPleinsEssenceForYear(int annee);

        /// <summary>Retourne la somme des pleins d'année par année</summary>
        /// <returns>Liste des sommes des pleins d'essence par année au format <PleinEssenceVM/></returns>
        List<PleinEssenceVM> GetPleinsEssenceParAnnees();
    }
}
