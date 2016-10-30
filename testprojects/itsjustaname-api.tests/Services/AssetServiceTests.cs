using System.Collections.Generic;
using System.Linq;
using itsjustaname_api.Models;
using itsjustaname_api.Repositories.Interfaces;
using itsjustaname_api.Services.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace itsjustaname_api.tests.Services
{
    [TestFixture]
    public class AssetServiceTests
    {
        [Test]
        public void Get_GetsAssetsUsingRepository()
        {
            var assetRepository = Substitute.For<IAssetRepository>();
            assetRepository.GetAll().Returns(new List<AssetModel>() {new AssetModel()});
            var mapper = MapperConfig.Initialise();
            var assetService = new AssetService(assetRepository, mapper);
            var assets = assetService.GetAll();
            Assert.AreEqual(1, assets.Count());
        }
    }
}