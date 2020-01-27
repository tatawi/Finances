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

        List<ConsommationElecAnnuelle> GetAllConsosElec();

        ConsommationElecAnnuelle GetConsoElecAnnee(int annee);

        bool PostConsommationAnnee(_ConsoElec_POST vm);
    }
}
