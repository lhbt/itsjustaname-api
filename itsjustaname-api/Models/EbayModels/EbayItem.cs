using itsjustaname_api.Models.EbayModels;
using Newtonsoft.Json;

namespace itsjustaname_api.Models.EbayModels
{
    public class EbayItem
    {
        [JsonProperty("title")]
        public string[] Name { get; set; }

        [JsonProperty("sellingStatus")]
        public SellingStatus[] Prices { get; set; }

        [JsonProperty("galleryUrl")]
        public string[] ImageUrl { get; set; }

        [JsonProperty("galleryPlusPictureURL")]
        public string[] BigImageUrl { get; set; }

        [JsonProperty("viewItemURL")]
        public string[] ItemUrl { get; set; }
    }
}