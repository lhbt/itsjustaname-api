using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace itsjustaname_api.ViewModels
{
    public class DailyTransactionBlockViewModel
    {
        [JsonProperty("avgSpend")]
        public long? AvgSpend { get; set; }

        [JsonProperty("avgReceived")]
        public long? AvgReceived { get; set; }

        [JsonProperty("transactions")]
        public IEnumerable<TransactionViewModel> Transactions { get; set; }

        [JsonProperty("date")]
        public DateTime? Date { get; set; }
    }
}