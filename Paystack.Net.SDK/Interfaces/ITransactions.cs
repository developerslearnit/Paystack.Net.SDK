
using Paystack.Net.SDK.Models;
using Paystack.Net.SDK.Models.Authorizations;
using Paystack.Net.SDK.Models.Exports;
using Paystack.Net.SDK.Models.TransTotal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.SDK
{
    public interface ITransactions
    {
        Task<PaymentInitalizationResponseModel> InitializeTransaction(string email, int amount,string firstName = null, 
            string lastName = null, string callbackUrl =null, string reference = null, bool makeReferenceUnique = false);

        Task<PaymentInitalizationResponseModel> InitializeTransaction(TransactionInitializationRequestModel requestObj);

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
