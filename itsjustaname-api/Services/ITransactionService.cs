using System.Collections.Generic;
using itsjustaname_api.ViewModels;

namespace itsjustaname_api.Services
{
    public interface ITransactionService
    {
        string GetTransactionsAsJson();
        IEnumerable<DailyTransactionBlockViewModel> GetTransactions();
    }
}