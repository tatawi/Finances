using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Consommation;

namespace Finance.Business.Interface.Services
{
    public interface IConsoEauService
    {

        /// <summary>Retourne la consommation d'eau d'une année</summary>
        /// <param name="annee">Année concernée</param>
        ConsommationEauAnnuelleVM GetConsommationEauAnnee(int annee);

        /// <summary>Retourne toutes les consomations d'eau</summary>
        List<ConsommationEauAnnuelleVM> GetConsommationEau();

        /// <summary>Retourne la liste des valeurs de l'estimation max par année</summary>
        /// <param name="vm">Consommation d'une année</param>
        /// <returns>true si ajout OK</returns>
        bool PostConsommationAnnee(ConsommationEauAnnuelleVM vm);
    }
}
