using AutoMapper;
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
            var transactionRepository = Substitute.For<IDailyTransactionBlockRepository>();
            var itemSearchService = Substitute.For<IItemImageSearchService>();
            var mapper = MapperConfig.Initialise();
            var service = new TransactionService(transactionRepository, mapper, Substitute.For<IUpgradeSpendingService>(), itemSearchService);
            var result = service.GetTransactionsAsJson();

            transactionRepository.Received(1).GetAllDailyTransactionBlocks();
            Assert.IsTrue(JSON.IsJsonArray(result));
        }
    }
}