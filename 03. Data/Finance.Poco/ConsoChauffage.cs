using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finance.Poco
{
    public class ConsoChauffage
    {


        public ConsoChauffage() { }

        

        public int ConsoChauffageId { get; set; }
        public int Annee { get; set; }
        public int ConsoTotale { get; set; }
        public int ConsoPerso { get; set; }
        public int CoutTotal { get; set; }
        public int CoutPerso { get; set; }
        public int KwhTotal { get; set; }
        public int KwhPerso { get; set; }
        public decimal CoutKwh { get; set; }

        public int CoutPersoAllRepartit { get; set; }
        public int CoutPersoRepartit { get; set; }
        public int CoutPersoNonRepartit { get; set; }


        public void CalculerRepartition()
        {
            try
            {
                var coutImmeuble = this.CoutTotal;


                //Cout si aucune répartition
                this.CoutPersoNonRepartit = (int)((coutImmeuble * 69) / 10000);

                //Controle
                if (this.ConsoPerso==0 || this.ConsoTotale==0)
                {
                    this.CoutPersoRepartit = 0;
                    this.CoutPersoAllRepartit = 0;
                    return;
                }

                
                //Cout si full répartition
                this.CoutPersoAllRepartit = (int)((coutImmeuble * this.ConsoPerso) / this.ConsoTotale);

                //Cout répartition 30/70
                var coutImmeublePourIndividuel = coutImmeuble * 0.7;
                var coutImmeublePourCommun = coutImmeuble - coutImmeublePourIndividuel;
                var coutPersoPourCommun = (coutImmeublePourCommun * 69) / 10000;
                var coutPersoPourIndividuel = (this.ConsoPerso * coutImmeublePourIndividuel) / this.ConsoTotale;

                this.CoutPersoRepartit = (int)(coutPersoPourCommun + coutPersoPourIndividuel);
            }
            catch(Exception)
            {
                this.CoutPersoRepartit = 0;
            }

            
        }

    }
}