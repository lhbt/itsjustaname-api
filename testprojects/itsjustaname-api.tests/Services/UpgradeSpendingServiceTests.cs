using System.Linq;
using itsjustaname_api.Repositories;
using itsjustaname_api.Services;
using NUnit.Framework;

namespace itsjustaname_api.tests.Services
{
    [TestFixture]
    public class UpgradeSpendingServiceTests
    {
        [Test]
        public void GivenTescoAsParameter_ReturnWaitroseUpgrade()
        {
            var upgradeRepo = new UpgradeSpendingRepository();
            var upgradeSpendingService = new UpgradeSpendingService(upgradeRepo);
            var upgrades = upgradeSpendingService.FindUpgrade("tesco");

            Assert.IsTrue(upgrades.Any(u => u.Name.ToLower() == "waitrose"));
            Assert.IsTrue(upgrades.Any(u => u.Name.ToLower() == "morrisons"));
        }
    }
}