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
        public void ItShouldReturnASpendObject()
        {
            var keywordsRepository = Substitute.For<IKeywordRepository>();
            var sut = new SpendService(keywordsRepository);

            var actual = sut.GetRandomIdea();

            Assert.That(actual, Is.TypeOf(typeof(SpendModel)));
        }

        [Test]
        public void ItShouldPickAKeywordAtRandom()
        {
            var keywordsRepository = Substitute.For<IKeywordRepository>();
            var sut = new SpendService(keywordsRepository);

            var actual = sut.GetRandomIdea();

            keywordsRepository.Received().GetRandomKeyword();
        }
    }
}
