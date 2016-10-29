using System.Collections.Generic;
using itsjustaname_api.Models;

namespace itsjustaname_api.Repositories
{
    public interface ITransactionRepository
    {
        IEnumerable<TransactionModel> GetAll();
    }
}