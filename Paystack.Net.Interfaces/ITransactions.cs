using Paystack.Net.Models;
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

        Task<TransactionVerificationResponseModel> VerifyTransaction(string reference);
    }
}
