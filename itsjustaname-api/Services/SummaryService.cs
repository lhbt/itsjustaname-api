using System;
using System.Collections.Generic;
using System.Linq;
using itsjustaname_api.Models;
using itsjustaname_api.Modules;
using itsjustaname_api.Services.Interfaces;
using itsjustaname_api.ViewModels;

namespace itsjustaname_api.Services
{
    public class SummaryService : ISummaryService
    {
        private readonly ITransactionService _transactionService;
        private readonly ISpendService _spendService;

        public SummaryService(ITransactionService transactionService, ISpendService spendService)
        {
            _transactionService = transactionService;
            _spendService = spendService;
        }

        public SummaryModel GetSummary(UserData userData)
        {
            var transactions = _transactionService.GetTransactions(userData);

            return GetSummaryModelForTransactions(transactions);
        }

        public SummaryModel GetSummary()
        {
            var transactions = _transactionService.GetTransactions();

            return GetSummaryModelForTransactions(transactions);
        }

        private SummaryModel GetSummaryModelForTransactions(IEnumerable<DailyTransactionBlockViewModel> transactions)
        {
            var totalSpent = transactions.Sum(x => x.TotalSpent);
            var totalReceived = transactions.Sum(x => x.TotalReceived);
            var avgDailySpend = Math.Round(transactions.Average(x => x.TotalSpent), 0);

            var capital = totalReceived - totalSpent;
            var capitalBeforeSpend = capital;

            var spendingSuggestions = new List<SpendModel>();

            while (capital > 0)
            {
                var spendIdea = _spendService.GetRandomIdea();

                spendingSuggestions.Add(spendIdea);
                capital = capital - spendIdea.Price;
            }

            return new SummaryModel
            {
                TotalSpent = totalSpent,
                TotalReceived = totalReceived,
                AverageDailySpend = avgDailySpend,
                Capital = capitalBeforeSpend,
                SpendingSuggestions = spendingSuggestions
            };
        }
    }
}