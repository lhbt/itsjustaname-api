using System.Collections.Generic;
using itsjustaname_api.Models;

namespace itsjustaname_api.Repositories
{
    public interface IDailyTransactionBlockRepository
    {
        IEnumerable<DailyTransactionBlockModel> GetAllDailyTransactionBlocks();
        IEnumerable<DailyTransactionBlockModel> GetDailyTransactionBlocks(UserData userData);
    }
}