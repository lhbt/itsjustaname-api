using System.Collections.Generic;
using itsjustaname_api.Models;

namespace itsjustaname_api.Repositories
{
    public class UpgradeSpendingRepository : IUpgradeSpendingRepository
    {
        private static readonly UpgradeModel WaitroseUpgrade = new UpgradeModel
        {
            ImageUrl = "http://vectorlogofree.com/wp-content/uploads/2014/06/waitrose-vector-logo-400x400.png",
            Name = "Waitrose",
            Notes = "You won't believe this! Guaranteed 50% increase in quality for an estimate of 150 pounds for similar purchase!",
            Link = "http://www.waitrose.com/"
        };

        private static readonly UpgradeModel MorrisonsUpgrade = new UpgradeModel
        {
            ImageUrl = "http://www.underconsideration.com/brandnew/archives/morrisons_logo.png",
            Name = "Morrisons",
            Notes = "AMAZING - Only 125 pounds for an amazing 25% increase in quality!",
            Link = "https://groceries.morrisons.com"
        };

        private readonly IDictionary<string, IEnumerable<UpgradeModel>> _upgradePaths = new Dictionary
            <string, IEnumerable<UpgradeModel>>
            {
                {"tesco", new List<UpgradeModel>() {WaitroseUpgrade, MorrisonsUpgrade}}
            };

        public IEnumerable<UpgradeModel> GetUpgrades(string name)
        {
            if (_upgradePaths.ContainsKey(name))
            {
                return _upgradePaths[name];
            }

            return new List<UpgradeModel>();
        }
    }
}