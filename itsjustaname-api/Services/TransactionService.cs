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

        public TransactionService(IDailyTransactionBlockRepository dailyTransactionBlockRepository, IMapper mapper)
        {
            _dailyTransactionBlockRepository = dailyTransactionBlockRepository;
            _mapper = mapper;
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
            return mappedTransactions;
        }

        private IEnumerable<DailyTransactionBlockViewModel> MapToDailyTransactionBlockViewModel(IEnumerable<DailyTransactionBlockModel> transactions)
        {
            var orderedTransactions = transactions.OrderByDescending(t => t.Date);
            var mappedTransactions = _mapper.Map<IEnumerable<DailyTransactionBlockViewModel>>(orderedTransactions);

            return mappedTransactions;
        }
    }
}