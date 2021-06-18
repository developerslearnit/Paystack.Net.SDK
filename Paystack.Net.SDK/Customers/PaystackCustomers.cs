using Newtonsoft.Json;
using Paystack.Net.SDK.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.SDK.Customers
{
    public class PaystackCustomers : ICustomers
    {

        private string _secretKey;
        public PaystackCustomers(string secretKey)
        {
            this._secretKey = secretKey;
        }

      

        public async Task<CustomerCreationResponse> CreateCustomer(string email, string firstname = null, string lastname = null,string phone=null)
        {
            var client = HttpConnection.CreateClient(this._secretKey);

            var bodyKeyValues = new List<KeyValuePair<string, string>>();

            bodyKeyValues.Add(new KeyValuePair<string, string>("email", email));
            bodyKeyValues.Add(new KeyValuePair<string, string>("first_name", firstname));
            bodyKeyValues.Add(new KeyValuePair<string, string>("last_name", lastname));
            bodyKeyValues.Add(new KeyValuePair<string, string>("phone", phone));

            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PostAsync("customer", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CustomerCreationResponse>(json);
        }

        public async Task<CustomerCreationResponse> FetchCustomer(int id)
        {
            var client = HttpConnection.CreateClient(this._secretKey);
            var response = await client.GetAsync($"customer/{id}");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CustomerCreationResponse>(json);
        }

        public async Task<CustomerListResponse> ListCustomers()
        {
            var client = HttpConnection.CreateClient(this._secretKey);
            var response = await client.GetAsync("customer");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CustomerListResponse>(json);
        }
    }
}
