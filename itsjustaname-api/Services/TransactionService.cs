using System.Collections.Generic;
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

        public TransactionService(IDailyTransactionBlockRepository dailyTransactionBlockRepository, IMapper mapper, IItemImageSearchService itemImageSearchService)
        {
            _dailyTransactionBlockRepository = dailyTransactionBlockRepository;
            _mapper = mapper;
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

            var mappedTransactions = MapToDailyTransactionBlockViewModel(transactions);

            //AppendImagesTo(mappedTransactions);

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

            return mappedTransactions;
        }
    }
}