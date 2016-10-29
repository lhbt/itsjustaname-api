using System.Collections.Generic;
using itsjustaname_api.Models;

namespace itsjustaname_api.Repositories
{
    public interface IUpgradeSpendingRepository
    {
        IEnumerable<UpgradeModel> GetUpgrades(string name);
    }
}