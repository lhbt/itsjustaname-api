using System;
using System.Collections.Generic;
using System.IO;
using itsjustaname_api.Models;
using Newtonsoft.Json;

namespace itsjustaname_api.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public IEnumerable<TransactionModel> GetAll()
        {
            var result = GetTransactionsFromFile();
            return result;
        }

        private IEnumerable<TransactionModel> GetTransactionsFromFile()
        {
            var startupPath = AppDomain.CurrentDomain.BaseDirectory;
            var result = JsonConvert.DeserializeObject<TransactionModel[]>(File.ReadAllText(startupPath + "/MockData/mock.json"));
            return result;
        }
    }
}