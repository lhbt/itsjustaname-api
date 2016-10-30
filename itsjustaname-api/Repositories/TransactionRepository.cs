using System;
using System.Collections.Generic;
using System.IO;
using itsjustaname_api.Models;
using itsjustaname_api.Repositories.Interfaces;
using Newtonsoft.Json;

namespace itsjustaname_api.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public TransactionRepository()
        {
            _defaultTransactions = GetTransactionsFromFile();
        }

        private readonly IEnumerable<TransactionModel> _defaultTransactions;

        public IEnumerable<TransactionModel> GetAll()
        {
            return _defaultTransactions;
        }

        private IEnumerable<TransactionModel> GetTransactionsFromFile()
        {
            var startupPath = AppDomain.CurrentDomain.BaseDirectory;
            var result = JsonConvert.DeserializeObject<TransactionModel[]>(File.ReadAllText(startupPath + "/MockData/mock.json"));
            return result;
        }
    }
}