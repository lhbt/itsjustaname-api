using System.Collections.Generic;
using System.Linq;
using itsjustaname_api.Models;
using itsjustaname_api.Repositories.Interfaces;
using itsjustaname_api.Services;
using NSubstitute;
using NUnit.Framework;

namespace itsjustaname_api.tests.Services
{
    [TestFixture]
    public class FindAlternativeIncomeServiceTests
    {
        [Test]
        public void Foo()
        {
            var defaultAlternativeIncomeRepository = Substitute.For<IGetDefaultAlternativeIncomeRepository>();
            defaultAlternativeIncomeRepository.GetAll().Returns(new List<AlternativeIncomeModel>() {new AlternativeIncomeModel(), new AlternativeIncomeModel()});
            var mapper = MapperConfig.Initialise();
            var service = new FindAlternativeIncomeService(defaultAlternativeIncomeRepository, mapper);
            var results = service.GetAll();

            Assert.AreEqual(2, results.Count());
        }
    }
}