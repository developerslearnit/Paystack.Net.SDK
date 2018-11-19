using Newtonsoft.Json;
using Paystack.Net.Interfaces;
using Paystack.Net.Models.Customers;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Paystack.Net.SDK.Customers
{
    public class PaystackCustomers : ICustomers
    {

        private string _secretKey;
        public PaystackCustomers(string secretKey)
        {
            _secretKey = secretKey;
        }     

        public async Task<CustomerCreationResponse> CreateCustomer(string email, string firstname = null, string lastname = null,string phone=null)
        {
            var client = HttpConnection.CreateClient(_secretKey);

            var bodyKeyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("first_name", firstname),
                new KeyValuePair<string, string>("last_name", lastname),
                new KeyValuePair<string, string>("phone", phone)
            };

            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PostAsync("customer", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CustomerCreationResponse>(json);
        }
        //metadata should be formated to json string
        //I dont know what option you would prefer, I think metadata can contain optional data as may be required by a specific business. I my case case I can supply first_name in the metadata
        public async Task<CustomerCreationResponse> CreateCustomer(string email, string metadata, string phone)
        {
            var client = HttpConnection.CreateClient(_secretKey);

            var bodyKeyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("phone", phone),
                new KeyValuePair<string, string>("metadata", metadata)
            };

            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PostAsync("customer", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CustomerCreationResponse>(json);
        }
        public async Task<CustomerCreationResponse> FetchCustomer(int id)
        {
            var client = HttpConnection.CreateClient(_secretKey);
            var response = await client.GetAsync($"customer/{id}");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CustomerCreationResponse>(json);
        }

        public async Task<CustomerListResponse> ListCustomers()
        {
            var client = HttpConnection.CreateClient(_secretKey);
            var response = await client.GetAsync("customer");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CustomerListResponse>(json);
        }
    }
}
