using System.Collections.Generic;
using itsjustaname_api.Models;

namespace itsjustaname_api.Services
{
    public class UpgradeSpendingService : IUpgradeSpendingService
    {
        public IEnumerable<UpgradeModel> FindUpgrade(string name)
        {
            var results = new List<UpgradeModel>();

            if (name == "tesco")
            {
                var waitroseUpgrade = new UpgradeModel()
                {
                    ImageUrl = "http://vectorlogofree.com/wp-content/uploads/2014/06/waitrose-vector-logo-400x400.png",
                    Name = "Waitrose",
                    Notes = "You won't believe this! Guaranteed 50% increase in quality for an estimate of 150 pounds for similar purchase!",
                    Link = "http://www.waitrose.com/"
                };

                var morrisonsUpgrade = new UpgradeModel()
                {
                    ImageUrl = "http://www.underconsideration.com/brandnew/archives/morrisons_logo.png",
                    Name = "Morrisons",
                    Notes = "AMAZING - Only 125 pounds for an amazing 25% increase in quality!",
                    Link = "https://groceries.morrisons.com"
                };

                results.Add(waitroseUpgrade);
                results.Add(morrisonsUpgrade);
            }

            return results;
        }
    }
}