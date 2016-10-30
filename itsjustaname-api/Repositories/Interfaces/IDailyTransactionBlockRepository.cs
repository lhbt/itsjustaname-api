using System.Collections.Generic;
using itsjustaname_api.Models;
using itsjustaname_api.Modules;

namespace itsjustaname_api.Repositories.Interfaces
{
    public interface IDailyTransactionBlockRepository
    {
        IEnumerable<DailyTransactionBlockModel> GetAllDailyTransactionBlocks();
        IEnumerable<DailyTransactionBlockModel> GetDailyTransactionBlocks(UserData userData);
    }
}