using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.ApodApi.Interface.ViewModel
{
    public class ApodApiJsonGet
    {

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("explanation")]
        public string Description { get; set; }

        [JsonProperty("hdurl")]
        public string Url { get; set; }
        [JsonProperty("url")]
        public string UrlLight { get; set; }

        [JsonProperty("title")]
        public string Titre { get; set; }

       

    }
}
