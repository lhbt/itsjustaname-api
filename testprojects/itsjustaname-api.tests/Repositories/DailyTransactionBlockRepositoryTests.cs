using System.Collections.Generic;
using System.Linq;
using itsjustaname_api.Models;
using itsjustaname_api.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace itsjustaname_api.tests.Repositories
{
    [TestFixture]
    public class DailyTransactionBlockRepositoryTests
    {
        [Test]
        public void Foo()
        {
            var transactionRepo = Substitute.For<ITransactionRepository>();
            transactionRepo.GetAll().Returns(new List<TransactionModel>() { new TransactionModel()});
            var repo = new DailyTransactionBlockRepository(transactionRepo);
            var results = repo.GetAllDailyTransactionBlocks();
            Assert.That(results.Count(), Is.GreaterThan(0));
        }
    }
}