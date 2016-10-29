using itsjustaname_api.Services;
using Newtonsoft.Json;

namespace itsjustaname_api.Models.EbayModels
{
    public class SellingStatus
    {
        [JsonProperty("convertedCurrentPrice")]
        public Prices[] ConvertedPrice { get; set; }
    }
}