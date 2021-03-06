﻿using Newtonsoft.Json;

namespace itsjustaname_api.ViewModels
{
    public class TransactionViewModel
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("amount")]
        public long? Amount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty("hasUpgrade")]
        public bool HasUpgrade { get; set; }
    }
}