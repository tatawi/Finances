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
        List<ConsommationEnergieAnnuelleVM> GetConsoEnergie(string user);
    }
}
