using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Consommation;

namespace Finance.Business.Interface.Services
{
    /// <summary>Gestion de la consommation d'électricité</summary>
    public interface IConsoElecService
    {
        /// <summary>Retourne toutes les consommations électriques de l'utilisateur courant</summary>
        /// <returns>Liste des consommations d'électricité annuelle au format <ConsommationElecAnnuelle/></returns>
        List<ConsommationElecAnnuelle> GetAllConsosElec();

        /// <summary>Retourne la consommation électrique annuelle de l'utilisateur courant</summary>
        /// <param name="annee">Année concernée</param>
        /// <returns>Consommation d'electricité annuelle au format <ConsommationElecAnnuelle/></returns>
        ConsommationElecAnnuelle GetConsoElecAnnee(int annee);

        /// <summary>Enregistre une consommation électrique annuelle pour l'utilisateur courant</summary>
        /// <param name="vm">Données au format <_ConsoElec_POST/></param>
        /// <returns>True si la consomation est enregistrée</returns>
        bool PostConsommationAnnee(_ConsoElec_POST vm);
    }
}
