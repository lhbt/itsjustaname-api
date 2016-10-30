using Newtonsoft.Json;

namespace itsjustaname_api.Models.EbayModels
{
    public class Prices
    {
        [JsonProperty("@currencyId")]
        public string Currency { get; set; }

        [JsonProperty("__value__")]
        public double Value { get; set; }
    }
}