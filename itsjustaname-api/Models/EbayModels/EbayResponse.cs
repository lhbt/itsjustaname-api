using Newtonsoft.Json;

namespace itsjustaname_api.Models.EbayModels
{
    public class EbayResponse
    {
        [JsonProperty("findItemsByKeywordsResponse")]
        public ResponseItem[] ResponseItems { get; set; }
    }
}