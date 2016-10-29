using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace itsjustaname_api.ViewModels
{
    public class SummaryViewModel
    {
        [JsonProperty("avgDailySpend")]
        public double AverageDailySpend { get; set; }

        [JsonProperty("totalReceived")]
        public double TotalReceived { get; set; }

        [JsonProperty("totalSpent")]
        public double TotalSpent { get; set; }
    }
}