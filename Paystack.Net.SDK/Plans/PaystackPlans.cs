using Newtonsoft.Json;
using Paystack.Net.Interfaces;
using Paystack.Net.Models.Plans;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Paystack.Net.SDK.Plans
{
    public class PaystackPlans : IPlans
    {
        string _secretKey;
        public PaystackPlans(string secretKey)
        {
            _secretKey = secretKey;
        }

        public async Task<PlansModel> CreatePlan(string name, string description, int amount, string interval, 
            bool send_invoices = false, bool send_sms = false, string currency = "NGN", int invoice_limit = 0)
        {
            var client = HttpConnection.CreateClient(_secretKey);

            var bodyKeyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("name", name),
                new KeyValuePair<string, string>("description", description),
                new KeyValuePair<string, string>("amount", amount.ToString()),
                new KeyValuePair<string, string>("interval", interval),
                new KeyValuePair<string, string>("send_invoices", send_invoices.ToString()),
                new KeyValuePair<string, string>("send_sms", send_sms.ToString()),
                new KeyValuePair<string, string>("currency", currency)
            };
            if (invoice_limit > 0)
            {
                bodyKeyValues.Add(new KeyValuePair<string, string>("invoice_limit", invoice_limit.ToString()));
            }

            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PostAsync("plan", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PlansModel>(json);

        }

        public async Task<FetchPlanModel> FetchPlans(string plan_code)
        {
            var client = HttpConnection.CreateClient(_secretKey);

            var response = await client.GetAsync($"plan/{plan_code}");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<FetchPlanModel>(json);
        }

        public async Task<PlanListModel> ListPlans()
        {
            var client = HttpConnection.CreateClient(_secretKey);

            var response = await client.GetAsync("plan");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PlanListModel>(json);
        }
    }
}
