using Newtonsoft.Json;
using Paystack.Net.Contstants;
using Paystack.Net.Interfaces;
using Paystack.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.SDK.Transactions
{
    /// <summary>
    /// 
    /// </summary>
    public class PaystackTransaction : ITransactions
    {
        private string _secretKey;
        public PaystackTransaction(string secretKey)
        {
            this._secretKey = secretKey;
        }

        /// <summary>
        /// Sends body parameters to transaction initialization url
        /// </summary>
        /// <param name="email"></param>
        /// <param name="amount"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="callbackUrl"></param>
        /// <param name="reference"></param>
        /// <param name="makeReferenceUnique"></param>
        /// <returns>PaymentInitalizationResponseModel</returns>

        public async Task<PaymentInitalizationResponseModel> InitializeTransaction(string email, int amount, string firstName = null,
                                                                                string lastName = null,string callbackUrl =null, string reference = null, bool makeReferenceUnique = false)
        {

            var client = HttpConnection.CreateClient(this._secretKey);

            var bodyKeyValues = new List<KeyValuePair<string, string>>();

            bodyKeyValues.Add(new KeyValuePair<string, string>("email", email));
            bodyKeyValues.Add(new KeyValuePair<string, string>("amount", amount.ToString()));


            //Optional Params
            if (!string.IsNullOrWhiteSpace(firstName))
            {
                bodyKeyValues.Add(new KeyValuePair<string, string>("first_name", firstName));
            }
            if(!string.IsNullOrWhiteSpace(lastName))
            {
                bodyKeyValues.Add(new KeyValuePair<string, string>("last_name", lastName));
            }

            if (!string.IsNullOrWhiteSpace(callbackUrl))
            {
                bodyKeyValues.Add(new KeyValuePair<string, string>("callback_url", callbackUrl));
            }
            
            var formContent = new FormUrlEncodedContent(bodyKeyValues);
          
            var response = await client.PostAsync(BaseConstants.PaystackInitializeTransactionEndPoint, formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PaymentInitalizationResponseModel>(json);
        }

        /// <summary>
        /// Verifies transaction by reference number
        /// </summary>
        /// <param name="reference"></param>
        /// <returns>TransactionVerificationResponseModel</returns>

        public async Task<TransactionVerificationResponseModel> VerifyTransaction(string reference)
        {
            var client = HttpConnection.CreateClient(this._secretKey);
            var response = await client.GetAsync($"{BaseConstants.PaystackTransactionVerificationEndPoint}/{reference}");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TransactionVerificationResponseModel>(json);
        }
    }
}
