using Finance.ApodApi.Interface.Services;
using Finance.ApodApi.Interface.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Finance.ApodApi.Services
{
    public class ApodApiService : IApodApiService
    {
        private static readonly string ApodApiUrl = "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY";


        public ApodApiService()
        {

        }

        //Get image du jour
        public ApodApiJsonGet GetImageDuJour()
        {
            ApodApiJsonGet apod = new ApodApiJsonGet();

            try
            {
                //Appel API
                string json = this.ApodApiRest_Get();

                //Conversion 
                apod = JsonConvert.DeserializeObject<ApodApiJsonGet>(json);
            }
            catch(Exception)
            {
                //todo
                return apod;
            }

            return apod;

        }





        //Appel API APOD - GET
        private string ApodApiRest_Get()
        {
            HttpClient client = new HttpClient();

            var response = client.GetAsync(ApodApiUrl).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return responseString;
        }


    }
}
