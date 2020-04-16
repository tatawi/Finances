using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.ApodApi.Interface.ViewModel
{
    /// <summary>Retour de l'API APOD</summary>
    public class ApodApiJsonGet
    {

        /// <summary>Date</summary>
        [JsonProperty("date")]
        public string Date { get; set; }

        /// <summary>Description</summary>
        [JsonProperty("explanation")]
        public string Description { get; set; }

        /// <summary>URL principale</summary>
        [JsonProperty("hdurl")]
        public string Url { get; set; }

        /// <summary>URL plus légére</summary>
        [JsonProperty("url")]
        public string UrlLight { get; set; }

        /// <summary>Titre</summary>
        [JsonProperty("title")]
        public string Titre { get; set; }

        /// <summary>Type de média</summary>
        [JsonProperty("media_type")]
        public string Type { get; set; }


        
    }
}
