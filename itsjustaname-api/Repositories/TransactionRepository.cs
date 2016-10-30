using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using itsjustaname_api.Models;
using itsjustaname_api.Repositories.Interfaces;
using Newtonsoft.Json;

namespace itsjustaname_api.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public TransactionRepository()
        {
            _transactionStore = GetInitialTransactions();
        }

        private readonly IList<TransactionModel> _transactionStore;

        public IEnumerable<TransactionModel> GetAll()
        {
            return _transactionStore;
        }

        public void AddTransaction(TransactionModel transaction)
        {
            _transactionStore.Add(transaction);
        }

        private IList<TransactionModel> GetInitialTransactions()
        {
            var startupPath = AppDomain.CurrentDomain.BaseDirectory;
            var result = JsonConvert.DeserializeObject<TransactionModel[]>(File.ReadAllText(startupPath + "/MockData/mock.json"));
            return result.ToList();
        }
    }
}