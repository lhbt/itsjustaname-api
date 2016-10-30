using Newtonsoft.Json;


namespace itsjustaname_api.ViewModels
{
    public class AlternativeIncomeViewModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }
}