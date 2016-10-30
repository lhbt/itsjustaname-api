using itsjustaname_api.Models;
using itsjustaname_api.Repositories;
using itsjustaname_api.Repositories.Interfaces;
using itsjustaname_api.Services;
using itsjustaname_api.Services.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace itsjustaname_api.tests.Services
{
    [TestFixture]
    public class SpendServiceTests
    {
        [Test]
        public void ItShouldSendARequestToEbayBasedOnARandomKeyword()
        {
            var keywordsRepository = Substitute.For<IKeywordRepository>();
            const string keyword = "keyword";
            keywordsRepository.GetRandomKeyword().Returns(keyword);

            
            const string itemName = "WASHING MACHINE";
            const string imageUrl = "image url";
            const string bigImageUrl = "big image url";
            const string itemUrl = "item url";
            const double price = 29.99;

            var ebayService = Substitute.For<IEbayService>();
            ebayService.GetEbayProduct(keyword).Returns(new EbayProductModel
            {
                Price = price,
                BigImageUrl = bigImageUrl,
                ImageUrl = imageUrl,
                ItemUrl = itemUrl,
                Name = itemName
            });

            var mapper = MapperConfig.Initialise();

            var sut = new SpendService(keywordsRepository, ebayService, mapper);

            var actual = sut.GetRandomIdea();

            Assert.That(actual.Name, Is.EqualTo(itemName));
            Assert.That(actual.LinkToArticle, Is.EqualTo(itemUrl));
            Assert.That(actual.ImageUrl, Is.EqualTo(imageUrl));
            Assert.That(actual.Price, Is.EqualTo(price));
            Assert.That(actual.BigImageUrl, Is.EqualTo(bigImageUrl));
        }
    }
}
