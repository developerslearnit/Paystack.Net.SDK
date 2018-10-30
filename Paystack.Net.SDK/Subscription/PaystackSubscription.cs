using Newtonsoft.Json;
using Paystack.Net.Interfaces;
using Paystack.Net.Models.Subscription;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Paystack.Net.SDK.Subscription
{
    public class PaystackSubscription : ISubscriptions
    {
      
        string _secretKey;
        public PaystackSubscription(string secretKey)
        {
            _secretKey = secretKey;
        }

        public async Task<SubscriptionModel> CreateSubscription(string customerEmail, string planCode, string authorization, 
            string start_date)
        {
            var client = HttpConnection.CreateClient(_secretKey);

            var bodyKeyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("customer", customerEmail),
                new KeyValuePair<string, string>("plan", planCode),
                new KeyValuePair<string, string>("authorization", authorization),
                new KeyValuePair<string, string>("start_date", start_date)
            };

            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PostAsync("subscription", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SubscriptionModel>(json);

        }
    }
}
