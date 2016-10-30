using System.Collections.Generic;
using itsjustaname_api.Modules;
using itsjustaname_api.ViewModels;

namespace itsjustaname_api.Services.Interfaces
{
    public interface ITransactionService
    {
        string GetTransactionsAsJson();
        IEnumerable<DailyTransactionBlockViewModel> GetTransactions();
        IEnumerable<DailyTransactionBlockViewModel> GetTransactions(UserData userData);
    }
}