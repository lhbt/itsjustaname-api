using Newtonsoft.Json;

namespace itsjustaname_api.Models
{
    public class EbayProductModel
    {
        [JsonProperty("title")]
        public string Name { get; set; }

        [JsonProperty("sellingStatus.convertedCurrentPrice.__value__")]
        public double Price { get; set; }

        [JsonProperty("galleryUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("galleryPlusPictureURL")]
        public string BigImageUrl { get; set; }

        [JsonProperty("viewItemURL")]
        public string ItemUrl { get; set; }
    }
}