using Finance.Business.Interface.Services;
using Finance.Business.Managers;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Services
{
    public class CarboneService : ICarboneService
    {

        private CarboneManager _CarboneManager {get; set;}

        public CarboneService()
        {
            this._CarboneManager = new CarboneManager();
        }

        public void AjouterBilanCarbone(BilanCarbone bilan, string user)
        {
            _CarboneManager.AjouterBilanCarbone(bilan, user);
        }

        public List<BilanCarbone> GetAllBilans(string user)
        {
            return _CarboneManager.GetAllBilanCarbone(user);
        }

    }
}
