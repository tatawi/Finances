using Finance.Business.Interface.Services.Consommations;
using Finance.Business.Managers;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Services.Consommations
{
    public class ConsoChauffageService : IConsoChauffageService
    {

        private ConsoChauffageManager consoChauffageManager { get; set; }

        public ConsoChauffageService()
        {
            consoChauffageManager = new ConsoChauffageManager();
        }


        public List<ConsoChauffage> GetAllConsosChauffageGenerales()
        {
            return consoChauffageManager.GetAllInfosChauffage().OrderBy(v => v.Annee).ToList();
        }

    }
}
