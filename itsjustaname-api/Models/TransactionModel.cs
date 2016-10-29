using System;

namespace itsjustaname_api.Models
{
    public class TransactionModel
    {
        public long? Id { get; set; }
        public long? TargetAccountId { get; set; }
        public string CreditOrDebit { get; set; }
        public long? Amount { get; set; }
        public long? SignedAmount { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ContainerProduct { get; set; }
        public string Category { get; set; }
        public string Merchant { get; set; }
    }
}