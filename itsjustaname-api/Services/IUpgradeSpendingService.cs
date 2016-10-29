using System.Collections.Generic;
using itsjustaname_api.Models;

namespace itsjustaname_api.Services
{
    public interface IUpgradeSpendingService
    {
        IEnumerable<UpgradeModel> FindUpgrade(string name);
    }
}