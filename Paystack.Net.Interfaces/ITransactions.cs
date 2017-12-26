using Paystack.Net.Models;
using Paystack.Net.Models.Authorizations;
using Paystack.Net.Models.Exports;
using Paystack.Net.Models.TransTotal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.Interfaces
{
    public interface ITransactions
    {
        Task<PaymentInitalizationResponseModel> InitializeTransaction(string email, int amount, string firstName = null, 
            string lastName = null, string callbackUrl =null, string reference = null, bool makeReferenceUnique = false);

        Task<TransactionResponseModel> VerifyTransaction(string reference);

        Task<TransactionListViewModel> ListTransactions();

        Task<TransactionResponseModel> FetchTransaction(int id);

        Task<TransactionResponseModel> ChargeAuthorization(string authorization_code, string email, int amount);

        Task<TransactionResponseModel> TransactionTimeline(string reference);

        Task<TransactionTotal> TransactionTotals();

        Task<ExportResponseModel> ExportTransactions();

        Task<TransactionResponseModel> CheckAuthorization(string authorization_code, string email, int amount);

        Task<RequestAuthorizationModel> RequestReAuthorization(string authorization_code, string email, int amount);

    }
}
