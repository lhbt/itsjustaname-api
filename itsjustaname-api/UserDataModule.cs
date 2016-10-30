using System.Collections.Generic;
using itsjustaname_api.Models;
using itsjustaname_api.Repositories;
using itsjustaname_api.Services;
using itsjustaname_api.ViewModels;
using Nancy;
using Nancy.Extensions;
using Newtonsoft.Json;

namespace itsjustaname_api
{
    public class UserDataModule : NancyModule
    {
        public UserDataModule(ITransactionService transactionService, ISummaryService summaryService)
        {
            Post["/userdata"] = parameters =>
            {
                var jsonData = Request.Body.AsString();

                var userData = JsonConvert.DeserializeObject<UserData>(jsonData);

                var transactions = transactionService.GetTransactions(userData);
                var summary = summaryService.GetSummary(userData);

                var response = new
                {
                    transactions = transactions,
                    summary = summary
                };

                return Response.AsJson(response);
            };
        }
    }

    public class UserData
    {
        public List<TransactionModel> Transactions { get; set; }
    }
}