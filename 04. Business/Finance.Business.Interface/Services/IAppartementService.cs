using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Interface.Services
{
    public interface IAppartementService
    {
        /// <summary>Retourne la liste des valeurs de l'estimation max par année</summary>
        /// <param name="user">Utilisateur concerné</param>
        /// <returns>Liste des valeurs</returns>
        List<int> GetListeValeurApptParAnnees(string user);

        /// <summary>Retourne la derniére valeur de l'estimation pour une année</summary>
        /// <param name="user">Année concerné</param>
        /// <param name="user">Utilisateur concerné</param>
        /// <returns>Valeurs</returns>
        int GetListeValeurApptPourAnnee(int annee, string user);

        /// <summary>Retourne la liste de toutes les infos de l'appartement</summary>
        /// <param name="user">Utilisateur concerné</param>
        /// <returns>Liste des Infos Appartement</returns>
        List<InfoAppartement> GetAllListValeursAppartement(string user);

        /// <summary>Ajoute une estimation pour l'appartement à la date actuelle</summary>
        /// <param name="source">Origine de la provenance de l'estimation</param>
        /// <param name="montant">Montant de l'estimation</param>
        void AjouterEstimationAppartement(string source, decimal montant, string user);
    }
}
