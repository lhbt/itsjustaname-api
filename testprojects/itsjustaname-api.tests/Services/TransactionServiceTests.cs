using System.Collections.Generic;
using AutoMapper;
using CsQuery.Utility;
using itsjustaname_api.Models;
using itsjustaname_api.Modules;
using itsjustaname_api.Repositories;
using itsjustaname_api.Repositories.Interfaces;
using itsjustaname_api.Services;
using itsjustaname_api.Services.Interfaces;
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
            var dailyTransactionBlockRepository = Substitute.For<IDailyTransactionBlockRepository>();
            var itemSearchService = Substitute.For<IItemImageSearchService>();
            var mapper = MapperConfig.Initialise();
            var transactionRepo = Substitute.For<ITransactionRepository>();
            var service = new TransactionService(dailyTransactionBlockRepository, mapper, Substitute.For<IUpgradeSpendingService>(), itemSearchService, transactionRepo);
            var result = service.GetTransactionsAsJson();

            dailyTransactionBlockRepository.Received(1).GetAllDailyTransactionBlocks();
            Assert.IsTrue(JSON.IsJsonArray(result));
        }

        [Test]
        public void Post_MultipleTransactions_AddToTransactionRepo()
        {
            var dailyTransactionBlockRepository = Substitute.For<IDailyTransactionBlockRepository>();
            var transactionRepo = Substitute.For<ITransactionRepository>();
            var itemSearchService = Substitute.For<IItemImageSearchService>();
            var mapper = MapperConfig.Initialise();
            var service = new TransactionService(dailyTransactionBlockRepository, mapper, Substitute.For<IUpgradeSpendingService>(), itemSearchService, transactionRepo);

            var userData = new UserData() { Transactions = new List<TransactionModel>() {new TransactionModel()} };
            service.AddTransactions(userData);
            transactionRepo.Received(1).AddTransaction(Arg.Any<TransactionModel>());

        }
    }
}