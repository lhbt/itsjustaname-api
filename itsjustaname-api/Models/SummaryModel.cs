using System.Collections.Generic;

namespace itsjustaname_api.Models
{
    public class SummaryModel
    {
        public double AverageDailySpend { get; set; }
        public double TotalReceived { get; set; }
        public double TotalSpent { get; set; }
        public double Capital { get; set; }
        public List<SpendModel> SpendingSuggestions { get; set; }
    }
}