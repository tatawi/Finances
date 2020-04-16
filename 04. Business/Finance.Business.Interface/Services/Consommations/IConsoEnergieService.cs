using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Consommation;

namespace Finance.Business.Interface.Services
{
    public interface IConsoEnergieService
    {
        /// <summary>Retourne une liste de consommations annuelles d'énergie au format <ConsommationEnergieAnnuelleVM/></summary>
        /// <returns>Liste des consommations</returns>
        List<ConsommationEnergieAnnuelleVM> GetConsoEnergie();
    }
}
