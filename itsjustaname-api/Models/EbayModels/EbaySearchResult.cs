using Newtonsoft.Json;

namespace itsjustaname_api.Models.EbayModels
{
    public class EbaySearchResult
    {
        [JsonProperty("@count")]
        public int Count { get; set; }

        [JsonProperty("item")]
        public EbayItem[] Items { get; set; }
    }
}