using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace itsjustaname_api.ViewModels
{
    public class DailyTransactionBlockViewModel
    {
        [JsonProperty("totalSpent")]
        public double TotalSpent { get; set; }

        [JsonProperty("totalReceived")]
        public double TotalReceived { get; set; }

        [JsonProperty("transactions")]
        public IEnumerable<TransactionViewModel> Transactions { get; set; }

        [JsonProperty("date")]
        public DateTime? Date { get; set; }
    }
}