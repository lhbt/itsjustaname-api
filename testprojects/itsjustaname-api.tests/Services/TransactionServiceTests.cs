using CsQuery.Utility;
using itsjustaname_api.Repositories;
using itsjustaname_api.Services;
using NSubstitute;
using NUnit.Framework;

namespace itsjustaname_api.tests.Services
{
    [TestFixture]
    public class TransactionServiceTests
    {
        [Test]
        public void GetSerializedTransactions_ReturnsAllTransactionsSerialisedToJsonSuccesfully()
        {
            var transactionRepository = Substitute.For<IDailyTransactionBlockRepositoryTransactionRepository>();
            var service = new TransactionService(transactionRepository);
            var result = service.GetTransactions();

            transactionRepository.Received(1).GetAllDailyTransactionBlocks();
            Assert.IsTrue(JSON.IsJsonArray(result));
        }
    }
}