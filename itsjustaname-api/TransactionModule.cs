using Nancy;

namespace itsjustaname_api
{
    public class TransactionModule : NancyModule
    {
        public TransactionModule(IMockTransactionService transactionService)
        {
            Get["/transactions"] = _ => transactionService.GetTransactions();
        }
    }
}