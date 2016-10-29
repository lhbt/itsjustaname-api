using System;
using System.Collections.Generic;

namespace itsjustaname_api.Models
{
    public class DailyTransactionBlock
    {
        public DateTime? Date { get; set; }
        public IEnumerable<TransactionModel> Transactions { get; set; }
    }
}