using System.Collections.Generic;
using itsjustaname_api.Repositories;
using itsjustaname_api.Repositories.Interfaces;
using itsjustaname_api.Services;
using NSubstitute;
using NUnit.Framework;

namespace itsjustaname_api.tests.Services
{
    [TestFixture]
    public class ItemImageServiceTests
    {
        [Test]
        public void Search_GivenAName_PickFirstFromResults()
        {
            var nameToSearch = "tesco";
            var imageSearchRepo = Substitute.For<IItemImageSearchRepository>();
            var firstImage = "tesco.com/abc.png";
            var secondImage = "www.tesco.co.uk/logo.png";
            imageSearchRepo.Search(nameToSearch).Returns(new List<string>() { firstImage, secondImage});
            var itemImageSearchService = new ItemImageSearchService(imageSearchRepo);
            var result = itemImageSearchService.SearchImage(nameToSearch);

            Assert.AreEqual(result, firstImage);

        }
    }
}