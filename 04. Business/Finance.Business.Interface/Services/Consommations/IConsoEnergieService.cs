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
        /// <summary></summary>
        /// <returns></returns>
        List<ConsommationEnergieAnnuelleVM> GetConsoEnergie();
    }
}
