using Finance.ApodApi.Interface.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.ApodApi.Interface.Services
{
    /// <summary>Api APOD - Image du jour</summary>
    public interface IApodApiService
    {
        /// <summary>Appel de l'API APOD pour récupérer l'image du jour</summary>
        /// <returns>Données de l'image du jour au format <ApodApiJsonGet/></returns>
        ApodApiJsonGet GetImageDuJour();
    }
}
