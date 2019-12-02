using Finance.Data.bdd;
using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Business.Managers
{
    public class ConsoChauffageManager
    {

        private bdd_ConsoChauffage _bddChauffage { get; set; }

        public ConsoChauffageManager()
        {
            this._bddChauffage = new bdd_ConsoChauffage();
        }


        public List<ConsoChauffage> GetAllInfosChauffage()
        {
            return _bddChauffage.get_All();
        }

        //Ajout d'une consommation d'eau
        public bool AjouterInfoChauffage(ConsoChauffage conso)
        {
            try
            {
                if (_bddChauffage.IsChauffagePresent(conso))
                    _bddChauffage.Maj_Chauffage(conso);
                else
                    _bddChauffage.Add_Chauffage(conso);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


    }
}
