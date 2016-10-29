using System.Collections.Generic;
using System.Linq;
using itsjustaname_api.Models;

namespace itsjustaname_api.Repositories
{
    public class DailyTransactionBlockRepository : IDailyTransactionBlockRepository
    {
        private readonly ITransactionRepository _transactionRepo;

        public DailyTransactionBlockRepository(ITransactionRepository transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }

        public IEnumerable<DailyTransactionBlockModel> GetAllDailyTransactionBlocks()
        {
            var result = new List<DailyTransactionBlockModel>();

            var transactions = _transactionRepo.GetAll();

            var dailyTransactionBlocks = MapTransactionsToDailyBlocks(transactions);
            result.AddRange(dailyTransactionBlocks);

            return result;
        }

        private static IEnumerable<DailyTransactionBlockModel> MapTransactionsToDailyBlocks(IEnumerable<TransactionModel> transactions)
        {
            return transactions.GroupBy(t => t.CreatedDate).Select(ts => new DailyTransactionBlockModel
            {
                Date = ts.Key,
                Transactions = ts.ToList()
            });
        }
    }
}