using itsjustaname_api.Repositories;
using Newtonsoft.Json;

namespace itsjustaname_api.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IDailyTransactionBlockRepository _dailyTransactionBlockRepository;

        public TransactionService(IDailyTransactionBlockRepository dailyTransactionBlockRepository)
        {
            _dailyTransactionBlockRepository = dailyTransactionBlockRepository;
        }

        public string GetTransactions()
        {
            var transactions = _dailyTransactionBlockRepository.GetAllDailyTransactionBlocks();
            var result = JsonConvert.SerializeObject(transactions);
            return result;
        }
    }
}