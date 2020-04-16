using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Interface.Services.Consommations
{
    public interface IConsoChauffageService
    {

        /// <summary>Retourne la liste de toutes les consommations de chauffage au format <ConsoChauffage/></summary>
        /// <returns>Liste des consomations de chauffage</returns>
        List<ConsoChauffage> GetAllConsosChauffageGenerales();

    }
}
