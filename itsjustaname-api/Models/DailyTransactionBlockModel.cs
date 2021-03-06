﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace itsjustaname_api.Models
{
    public class DailyTransactionBlockModel
    {
        [JsonProperty("date")]
        public DateTime? Date { get; set; }

        [JsonProperty("transactions")]
        public IEnumerable<TransactionModel> Transactions { get; set; }
    }
}