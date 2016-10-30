using System.Collections.Generic;
using AutoMapper;
using itsjustaname_api.Models;
using itsjustaname_api.Repositories;
using itsjustaname_api.ViewModels;
using Nancy;
using Nancy.Extensions;
using Newtonsoft.Json;

namespace itsjustaname_api
{
    public class UserDataModule : NancyModule
    {
        public UserDataModule(IDailyTransactionBlockRepository dailyTransactionBlockRepository, IMapper mapper)
        {
            Post["/userdata"] = parameters =>
            {
                var jsonData = Request.Body.AsString();

                var userData = JsonConvert.DeserializeObject<UserData>(jsonData);

                var transactions = dailyTransactionBlockRepository.GetDailyTransactionBlocks(userData);

                var dailyTransactionBlockViewModels = new List<DailyTransactionBlockViewModel>();

                mapper.Map(transactions, dailyTransactionBlockViewModels);

                return Response.AsJson(dailyTransactionBlockViewModels);
            };
        }
    }

    public class UserData
    {
        public List<TransactionModel> Transactions { get; set; }
    }
}