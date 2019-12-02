using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Interface.Services
{
    public interface ICarboneService
    {

        /// <summary>Ajoute le bilan carbone d'une année en base</summary>
        /// <param name="bilan">Bilan carbone <BilanCarbone/></param>
        /// <param name="user">Utilisateur qui effectue l'ajout</param>
        void AjouterBilanCarbone(BilanCarbone bilan, string user);
    }
}
