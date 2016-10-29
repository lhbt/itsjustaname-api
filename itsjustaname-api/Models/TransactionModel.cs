using System;
using Newtonsoft.Json;

namespace itsjustaname_api.Models
{
    public class TransactionModel
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("targetAccountId")]
        public long? TargetAccountId { get; set; }

        [JsonProperty("creditOrDebit")]
        public string CreditOrDebit { get; set; }

        [JsonProperty("amount")]
        public long? Amount { get; set; }

        [JsonProperty("signedAmount")]
        public long? SignedAmount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("containerProduct")]
        public string ContainerProduct { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("merchant")]
        public string Merchant { get; set; }
    }
}