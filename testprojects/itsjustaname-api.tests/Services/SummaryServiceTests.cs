using System;
using System.Collections.Generic;
using itsjustaname_api.Services;
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

            var sut = new SummaryService(transactionService);

            var actual = sut.GetSummary();

            Assert.That(actual.TotalSpent, Is.EqualTo(60));
        }

        [Test]
        public void ItShouldReturnTheTotalAmountOfMoneyReceived()
        {
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

            var sut = new SummaryService(transactionService);

            var actual = sut.GetSummary();

            Assert.That(actual.TotalReceived, Is.EqualTo(60));
        }

        [Test]
        public void ItShouldReturnTheAvgSpendPerDay()
        {
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

            var sut = new SummaryService(transactionService);

            var actual = sut.GetSummary();
            
            Assert.That(actual.AverageDailySpend, Is.EqualTo(30));
        }
    }
}
