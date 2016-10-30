using Newtonsoft.Json;

namespace itsjustaname_api.ViewModels
{
    public class AssetViewModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("worth")]
        public long Worth { get; set; }
    }
}