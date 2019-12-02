using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Consommation;

namespace Finance.Business.Interface.Services
{
    public interface IConsoElecService
    {

        List<ConsommationElecAnnuelle> GetAllConsosElec(string user);

        ConsommationElecAnnuelle GetConsoElecAnnee(int annee, string user);

        bool PostConsommationAnnee(_ConsoElec_POST vm, string user);
    }
}
