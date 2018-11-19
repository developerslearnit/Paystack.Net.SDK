using Newtonsoft.Json;
using Paystack.Net.Contstants;
using Paystack.Net.Interfaces;
using Paystack.Net.Models;
using Paystack.Net.Models.Authorizations;
using Paystack.Net.Models.Exports;
using Paystack.Net.Models.TransTotal;
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

        public async Task<PaymentInitalizationResponseModel> InitializeTransaction(string email, int amount,string firstName = null,
                                                                                string lastName = null,string callbackUrl =null, 
                                                                                string reference = null, bool makeReferenceUnique = false)
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
          
            var response = await client.PostAsync("transaction/initialize", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PaymentInitalizationResponseModel>(json);
        }

        /// <summary>
        /// This methods initializes payment transactioons - It inlcude subaccount, transactioncharge etc
        /// </summary>
        /// <param name="email"></param>
        /// <param name="amount"></param>
        /// <param name="subaccount"></param>
        /// <param name="transaction_charge"></param>
        /// <param name="bearer"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="callbackUrl"></param>
        /// <param name="reference"></param>
        /// <param name="plan"></param>
        /// <param name="invoice_limit"></param>
        /// <param name="makeReferenceUnique"></param>
        /// <returns></returns>

        public async Task<PaymentInitalizationResponseModel> InitializeTransaction(TransactionInitializationRequestModel requestObj)
        {

            var client = HttpConnection.CreateClient(this._secretKey);

            var bodyKeyValues = new List<KeyValuePair<string, string>>();


            foreach (var property in requestObj.GetType().GetProperties())
            {
                if (property.GetValue(requestObj) != null)
                {
                    bodyKeyValues.Add(new KeyValuePair<string, string>(property.Name, property.GetValue(requestObj).ToString()));
                }
            }
          
            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PostAsync("transaction/initialize", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PaymentInitalizationResponseModel>(json);
        }



        /// <summary>
        /// Verifies transaction by reference number
        /// </summary>
        /// <param name="reference"></param>
        /// <returns>TransactionVerificationResponseModel</returns>

        public async Task<TransactionResponseModel> VerifyTransaction(string reference)
        {
            var client = HttpConnection.CreateClient(this._secretKey);
            var response = await client.GetAsync($"transaction/verify/{reference}");

            var json = await response.Content.ReadAsStringAsync();
          

            return JsonConvert.DeserializeObject<TransactionResponseModel>(json);
        }


        public async Task<TransactionListViewModel> ListTransactions()
        {
            var client = HttpConnection.CreateClient(this._secretKey);
            var response = await client.GetAsync("transaction");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TransactionListViewModel>(json);
        }

        public async Task<TransactionResponseModel> FetchTransaction(int id)
        {
            var client = HttpConnection.CreateClient(this._secretKey);
            var response = await client.GetAsync($"transaction/{id}");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TransactionResponseModel>(json);
        }

        public async Task<TransactionResponseModel> ChargeAuthorization(string authorization_code, string email, int amount)
        {
            var client = HttpConnection.CreateClient(this._secretKey);

            var bodyKeyValues = new List<KeyValuePair<string, string>>();

            bodyKeyValues.Add(new KeyValuePair<string, string>("authorization_code", authorization_code));
            bodyKeyValues.Add(new KeyValuePair<string, string>("email", email));
            bodyKeyValues.Add(new KeyValuePair<string, string>("amount", amount.ToString()));

            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PostAsync("transaction/charge_authorization", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TransactionResponseModel>(json);
        }



        public async Task<TransactionResponseModel> TransactionTimeline(string reference)
        {
            var client = HttpConnection.CreateClient(this._secretKey);
            var response = await client.GetAsync($"transaction/timeline/{reference}");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TransactionResponseModel>(json);
        }

        public async Task<TransactionTotal> TransactionTotals()
        {
            var client = HttpConnection.CreateClient(this._secretKey);
            var response = await client.GetAsync("transaction/totals");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TransactionTotal>(json);
        }

        public async Task<ExportResponseModel> ExportTransactions()
        {
            var client = HttpConnection.CreateClient(this._secretKey);
            var response = await client.GetAsync("transaction/export");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ExportResponseModel>(json);
        }

        public async Task<TransactionResponseModel> CheckAuthorization(string authorization_code, string email, int amount)
        {
            var client = HttpConnection.CreateClient(this._secretKey);

            var bodyKeyValues = new List<KeyValuePair<string, string>>();

            bodyKeyValues.Add(new KeyValuePair<string, string>("authorization_code", authorization_code));
            bodyKeyValues.Add(new KeyValuePair<string, string>("email", email));
            bodyKeyValues.Add(new KeyValuePair<string, string>("amount", amount.ToString()));

            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PostAsync("transaction/check_authorization", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TransactionResponseModel>(json);
        }

        public async Task<RequestAuthorizationModel> RequestReAuthorization(string authorization_code, string email, int amount)
        {
            var client = HttpConnection.CreateClient(this._secretKey);

            var bodyKeyValues = new List<KeyValuePair<string, string>>();

            bodyKeyValues.Add(new KeyValuePair<string, string>("authorization_code", authorization_code));
            bodyKeyValues.Add(new KeyValuePair<string, string>("email", email));
            bodyKeyValues.Add(new KeyValuePair<string, string>("amount", amount.ToString()));

            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PostAsync("transaction/request_reauthorization", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<RequestAuthorizationModel>(json);
        }
    }
}
