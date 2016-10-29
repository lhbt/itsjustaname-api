using itsjustaname_api.Services;
using Nancy;

namespace itsjustaname_api
{
    public class TransactionModule : NancyModule
    {
        public TransactionModule(ITransactionService transactionService)
        {
            Get["/transactions"] = _ => Response.AsText(transactionService.GetTransactions());
        }
    }
}