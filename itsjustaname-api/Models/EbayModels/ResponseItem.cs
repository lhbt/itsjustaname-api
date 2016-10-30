using System;

namespace itsjustaname_api.Models.EbayModels
{
    public class ResponseItem
    {
        public string[] Ack { get; set; }
        public string[] Version { get; set; }
        public DateTime[] Timestamp { get; set; }
        public EbaySearchResult[] SearchResult { get; set; }
    }
}