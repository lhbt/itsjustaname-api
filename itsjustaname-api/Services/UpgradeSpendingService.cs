using System.Collections.Generic;
using itsjustaname_api.Models;
using itsjustaname_api.Repositories;

namespace itsjustaname_api.Services
{
    public class UpgradeSpendingService : IUpgradeSpendingService
    {
        private readonly IUpgradeSpendingRepository _repository;

        public UpgradeSpendingService(IUpgradeSpendingRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UpgradeModel> FindUpgrade(string name)
        {
            var results = _repository.GetUpgrades(name.ToLower());
            
            return results;
        }
    }
}