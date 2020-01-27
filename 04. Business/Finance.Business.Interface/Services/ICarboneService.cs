using Finance.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Carbone;

namespace Finance.Business.Interface.Services
{
    public interface ICarboneService
    {

        /// <summary>Ajoute le bilan carbone d'une année en base</summary>
        /// <param name="bilan">Bilan carbone viewModel <BilanCarboneVM/> <BilanCarbone/></param>
        void AjouterBilanCarbone(BilanCarboneVM bilan);

        /// <summary>Retourne tous les bilans carbones de l'utilisateur</summary>
        /// <returns>Liste de <BilanCarbone/> annuels</returns>
        List<BilanCarbone> GetAllBilans();

        /// <summary>Retournele bilan carbone de l'utilisateur pour une année</summary>
        /// <param name="annee">Année concernée</param>
        /// <returns><BilanCarbone/> de l'année pour l'utilisateur</returns>
        BilanCarbone GetBilan(int annee);

        /// <summary>Retourne un bilan carbone détaillé</summary>
        /// <param name="annee">Année concerné</param>
        /// <returns><BilanCarboneDetails/> trouvé</returns>
        BilanCarboneDetails GetBilanDetaille(int annee);

        /// <summary>Ajoute un bilan carbone détaillé en base</summary>
        /// <param name="bil">Bialn carbone détaillé <BilanCarboneDetails/> à ajouter</param>
        void AjouterBilanCarboneDetaille(BilanCarboneDetails bil);
    }
}
