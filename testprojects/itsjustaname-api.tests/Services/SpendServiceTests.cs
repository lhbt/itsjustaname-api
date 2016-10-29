using itsjustaname_api.Models;
using itsjustaname_api.Repositories;
using itsjustaname_api.Services;
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
            const string itemUrl = "item url";
            const double price = 29.99;

            var ebayService = Substitute.For<IEbayService>();
            ebayService.GetEbayProduct(keyword).Returns(new EbayProductModel
            {
                Price = price,
                BigImageUrl = "big image url",
                ImageUrl = imageUrl,
                ItemUrl = itemUrl,
                Name = itemName
            });

            var sut = new SpendService(keywordsRepository, ebayService);

            var actual = sut.GetRandomIdea();

            Assert.That(actual.Name, Is.EqualTo(itemName));
            Assert.That(actual.LinkToArticle, Is.EqualTo(itemUrl));
            Assert.That(actual.ImageUrl, Is.EqualTo(imageUrl));
            Assert.That(actual.Price, Is.EqualTo(price));
        }
    }
}
