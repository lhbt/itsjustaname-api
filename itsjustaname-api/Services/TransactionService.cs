using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using itsjustaname_api.Models;
using itsjustaname_api.Repositories;
using itsjustaname_api.ViewModels;
using Newtonsoft.Json;

namespace itsjustaname_api.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IDailyTransactionBlockRepository _dailyTransactionBlockRepository;
        private readonly IMapper _mapper;
        private readonly IItemImageSearchService _itemImageSearchService;
        private readonly IUpgradeSpendingService _upgradeSpendingService;

        public TransactionService(IDailyTransactionBlockRepository dailyTransactionBlockRepository, IMapper mapper, IUpgradeSpendingService upgradeSpendingService, IItemImageSearchService itemImageSearchService)
        {
            _dailyTransactionBlockRepository = dailyTransactionBlockRepository;
            _mapper = mapper;
            _upgradeSpendingService = upgradeSpendingService;
            _itemImageSearchService = itemImageSearchService;
        }

        public string GetTransactionsAsJson()
        {
            var mappedTransactions = GetTransactions();

            var result = JsonConvert.SerializeObject(mappedTransactions);

            return result;
        }

        public IEnumerable<DailyTransactionBlockViewModel> GetTransactions()
        {
            var transactions = _dailyTransactionBlockRepository.GetAllDailyTransactionBlocks();

            var results = GetMappedTransactionsWithImages(transactions);
            results = results.OrderByDescending(r => r.Date);
            return results;
        }

        public IEnumerable<DailyTransactionBlockViewModel> GetTransactions(UserData userData)
        {
            var transactions = _dailyTransactionBlockRepository.GetDailyTransactionBlocks(userData);

            return GetMappedTransactionsWithImages(transactions);
        }

        private IEnumerable<DailyTransactionBlockViewModel> GetMappedTransactionsWithImages(IEnumerable<DailyTransactionBlockModel> transactions)
        {
            var mappedTransactions = MapToDailyTransactionBlockViewModel(transactions);

            AppendImagesTo(mappedTransactions);

            return mappedTransactions;
        }

        private void AppendImagesTo(IEnumerable<DailyTransactionBlockViewModel> dailyTransactionBlocks)
        {
            foreach (var dailyTransactionBlock in dailyTransactionBlocks)
            {
                foreach (var transaction in dailyTransactionBlock.Transactions)
                {
                    transaction.ImageUrl = _itemImageSearchService.SearchImage(transaction.Name);
                }
            }
        }

        private IEnumerable<DailyTransactionBlockViewModel> MapToDailyTransactionBlockViewModel(IEnumerable<DailyTransactionBlockModel> transactions)
        {
            var mappedTransactions = _mapper.Map<IEnumerable<DailyTransactionBlockViewModel>>(transactions);

            foreach (var dailyBlockTransaction in mappedTransactions)
            {
                foreach (var transaction in dailyBlockTransaction.Transactions)
                {
                    transaction.HasUpgrade = _upgradeSpendingService.FindUpgrade(transaction.Name).Any();
                }
            }
            
            return mappedTransactions;
        }
    }
}