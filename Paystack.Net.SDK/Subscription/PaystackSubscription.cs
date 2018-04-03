using Newtonsoft.Json;
using Paystack.Net.Interfaces;
using Paystack.Net.Models.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.SDK.Subscription
{
    public class PaystackSubscription : ISubscriptions
    {
      
        string _secretKey;
        public PaystackSubscription(string secretKey)
        {
            this._secretKey = secretKey;
        }

        public async Task<SubscriptionModel> CreateSubscription(string customerEmail, string planCode, string authorization, 
            string start_date)
        {
            var client = HttpConnection.CreateClient(this._secretKey);

            var bodyKeyValues = new List<KeyValuePair<string, string>>();

            bodyKeyValues.Add(new KeyValuePair<string, string>("customer", customerEmail));
            bodyKeyValues.Add(new KeyValuePair<string, string>("plan", planCode));
            bodyKeyValues.Add(new KeyValuePair<string, string>("authorization", authorization));
            bodyKeyValues.Add(new KeyValuePair<string, string>("start_date", start_date));

            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PostAsync("subscription", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SubscriptionModel>(json);

        }
    }
}
