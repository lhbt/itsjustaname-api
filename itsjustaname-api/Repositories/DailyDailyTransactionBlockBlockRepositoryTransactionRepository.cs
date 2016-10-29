using System.Collections.Generic;
using System.IO;
using itsjustaname_api.Models;
using Newtonsoft.Json;

namespace itsjustaname_api.Repositories
{
    public class DailyDailyTransactionBlockBlockRepositoryTransactionRepository : IDailyTransactionBlockRepositoryTransactionRepository
    {
        public IEnumerable<DailyTransactionBlock> GetAllDailyTransactionBlocks()
        {
            var result = new List<DailyTransactionBlock>();

            var transactions = GetTransactionsFromFile();
            return result;
        }

        private IEnumerable<TransactionModel> GetTransactionsFromFile()
        {
            var result = JsonConvert.DeserializeObject<TransactionModel[]>(File.ReadAllText("MockData/mock.json"));
            return result;
        }
    }
}