using System;
using System.Collections.Generic;
using System.Linq;
using itsjustaname_api.Models;
using itsjustaname_api.Modules;
using itsjustaname_api.Repositories.Interfaces;

namespace itsjustaname_api.Repositories
{
    public class DailyTransactionBlockRepository : IDailyTransactionBlockRepository
    {
        private readonly ITransactionRepository _transactionRepo;

        public DailyTransactionBlockRepository(ITransactionRepository transactionRepo)
        {
            _transactionRepo = transactionRepo;
        }

        public IEnumerable<DailyTransactionBlockModel> GetDailyTransactionBlocks(UserData userData)
        {
            return GetDailyTransactionBlockModels(userData.Transactions);
        }

        public IEnumerable<DailyTransactionBlockModel> GetAllDailyTransactionBlocks()
        {
            var transactions = _transactionRepo.GetAll();

            return GetDailyTransactionBlockModels(transactions);
        }

        private static IEnumerable<DailyTransactionBlockModel> GetDailyTransactionBlockModels(IEnumerable<TransactionModel> transactions)
        {
            var result = new List<DailyTransactionBlockModel>();

            var dailyTransactionBlocks = MapTransactionsToDailyBlocks(transactions);
            result.AddRange(dailyTransactionBlocks);

            return result;
        }

        private static IEnumerable<DailyTransactionBlockModel> MapTransactionsToDailyBlocks(IEnumerable<TransactionModel> transactions)
        {
            return transactions.GroupBy(t => GetDate(t.CreatedDate)).Select(ts => new DailyTransactionBlockModel
            {
                Date = ts.Key,
                Transactions = ts.ToList()
            });
        }

        private static DateTime? GetDate(DateTime? date)
        {
            if (date != null)
            {
                var dateValue = date.Value;
                var result = new DateTime(dateValue.Year, dateValue.Month, dateValue.Day);
                return result;
            }
            return new DateTime?();
        }
    }
}