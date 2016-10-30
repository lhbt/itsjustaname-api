using System;
using System.Collections.Generic;
using itsjustaname_api.Models;
using itsjustaname_api.Modules;
using itsjustaname_api.Services;
using itsjustaname_api.Services.Interfaces;
using itsjustaname_api.ViewModels;
using NSubstitute;
using NUnit.Framework;

namespace itsjustaname_api.tests.Services
{
    [TestFixture]
    public class SummaryServiceTests
    {
        [Test]
        public void ItShouldReturnTheTotalAmountOfMoneySpent()
        {
            var spendService = Substitute.For<ISpendService>();
            var transactionService = Substitute.For<ITransactionService>();
            transactionService.GetTransactions().Returns(new List<DailyTransactionBlockViewModel>
            {
                new DailyTransactionBlockViewModel
                {
                    TotalSpent = 40
                },
                new DailyTransactionBlockViewModel
                {
                    TotalSpent = 20
                }
            });

            var assetService = Substitute.For<IAssetService>();
            var sut = new SummaryService(transactionService, spendService, assetService);

            var actual = sut.GetSummary();

            Assert.That(actual.TotalSpent, Is.EqualTo(60));
        }

        [Test]
        public void ItShouldReturnTheTotalAmountOfMoneyReceived()
        {
            var spendService = Substitute.For<ISpendService>();
            spendService.GetRandomIdea().Returns(new SpendModel
            {
                Price = 50
            });

            var transactionService = Substitute.For<ITransactionService>();
            transactionService.GetTransactions().Returns(new List<DailyTransactionBlockViewModel>
            {
                new DailyTransactionBlockViewModel
                {
                    TotalReceived = 40
                },
                new DailyTransactionBlockViewModel
                {
                    TotalReceived = 20
                }
            });

            var assetService = Substitute.For<IAssetService>();
            var sut = new SummaryService(transactionService, spendService, assetService);

            var actual = sut.GetSummary();

            Assert.That(actual.TotalReceived, Is.EqualTo(60));
        }

        [Test]
        public void ItShouldReturnTheAvgSpendPerDay()
        {
            var spendService = Substitute.For<ISpendService>();
            var transactionService = Substitute.For<ITransactionService>();
            transactionService.GetTransactions().Returns(new List<DailyTransactionBlockViewModel>
            {
                new DailyTransactionBlockViewModel
                {
                    TotalSpent = 40
                },
                new DailyTransactionBlockViewModel
                {
                    TotalSpent = 20
                }
            });

            var assetService = Substitute.For<IAssetService>();
            var sut = new SummaryService(transactionService, spendService, assetService);

            var actual = sut.GetSummary();
            
            Assert.That(actual.AverageDailySpend, Is.EqualTo(30));
        }

        [Test]
        public void ItShouldHaveTotalAssetWorth()
        {
            var spendService = Substitute.For<ISpendService>();
            var transactionService = Substitute.For<ITransactionService>();
            transactionService.GetTransactions().Returns(new List<DailyTransactionBlockViewModel>
            {
                new DailyTransactionBlockViewModel
                {
                    TotalSpent = 40
                },
                new DailyTransactionBlockViewModel
                {
                    TotalSpent = 20
                }
            });

            var assetService = Substitute.For<IAssetService>();
            assetService.GetAll()
                .Returns(new List<AssetViewModel>()
                {
                    new AssetViewModel() {Worth = 50000},
                    new AssetViewModel() {Worth = 60000}
                });
            var sut = new SummaryService(transactionService, spendService, assetService);

            var actual = sut.GetSummary();

            Assert.That(actual.TotalAssetWorth, Is.EqualTo(110000));
        }

        [Test]
        public void ItShouldReturnASummaryModelForUserData()
        {
            var userData = new UserData
            {
                Transactions = new List<TransactionModel>
                {
                    new TransactionModel
                    {
                        CreditOrDebit = "Debit",
                        Amount = 2500,
                        Merchant = "tesco",
                        CreatedDate = new DateTime(2016, 10, 30)
                    }
                }
            };

            var spendService = Substitute.For<ISpendService>();
            var transactionService = Substitute.For<ITransactionService>();
            transactionService.GetTransactions(userData).Returns(new List<DailyTransactionBlockViewModel>
            {
                new DailyTransactionBlockViewModel
                {
                    Date = "30 October 2016",
                    TotalReceived = 0,
                    TotalSpent = 25,
                    Transactions = new List<TransactionViewModel>
                    {
                        new TransactionViewModel
                        {
                            HasUpgrade = true,
                            ImageUrl = "image url",
                            Name = "tesco",
                            Amount = 25,
                            Type = "Debit"
                        }
                    }
                }
            });

            var assetService = Substitute.For<IAssetService>();
            var sut = new SummaryService(transactionService, spendService, assetService);

            var actual = sut.GetSummary(userData);

            Assert.That(actual.Capital, Is.EqualTo(-25));
            Assert.That(actual.SpendingSuggestions, Is.Empty);
        }
    }
}
