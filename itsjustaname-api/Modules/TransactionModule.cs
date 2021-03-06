﻿using itsjustaname_api.Services.Interfaces;
using Nancy;

namespace itsjustaname_api.Modules
{
    public class TransactionModule : NancyModule
    {
        public TransactionModule(ITransactionService transactionService)
        {
            Get["/transactions"] = _ => Response.AsText(transactionService.GetTransactionsAsJson());
        }
    }
}