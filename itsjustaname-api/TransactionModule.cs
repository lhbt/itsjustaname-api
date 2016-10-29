using Nancy;

namespace itsjustaname_api
{
    public class TransactionModule : NancyModule
    {
        public TransactionModule(ITransactionService transactionService)
        {
            Get["/transactions"] = _ => transactionService.GetTransactions();
        }
    }
}