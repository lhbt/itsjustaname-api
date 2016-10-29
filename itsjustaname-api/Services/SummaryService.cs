using System.Linq;
using itsjustaname_api.Models;

namespace itsjustaname_api.Services
{
    public class SummaryService : ISummaryService
    {
        private readonly ITransactionService _transactionService;

        public SummaryService(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public SummaryModel GetSummary()
        {
            var transactions = _transactionService.GetTransactions();
            
            var totalSpent = transactions.Sum(x => x.TotalSpend);
            var totalReceived = transactions.Sum(x => x.TotalReceived);
            var avgDailySpend = transactions.Average(x => x.TotalSpend);

            return new SummaryModel
            {
                TotalSpent = totalSpent,
                TotalReceived = totalReceived,
                AverageDailySpend = avgDailySpend
            };
        }
    }
}