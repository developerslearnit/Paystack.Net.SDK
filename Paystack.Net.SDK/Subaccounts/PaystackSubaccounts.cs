using Newtonsoft.Json;
using Paystack.Net.Interfaces;
using Paystack.Net.Models.Subaccounts.CreateSubAccount;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Paystack.Net.SDK.Subaccounts
{
    public class PaystackSubaccounts : ISubAccounts
    {

        private string _secretKey;
        public PaystackSubaccounts(string secretKey)
        {
            _secretKey = secretKey;
        }

        public async Task<SubAccountModel> CreateSubAccount(string business_name, string settlement_bank, string account_number,
                                float percentage_charge, string primary_contact_email = null, string primary_contact_name = null,
                                string primary_contact_phone = null, string settlement_schedule = "auto")
        {
            var client = HttpConnection.CreateClient(_secretKey);

            var bodyKeyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("business_name", business_name),
                new KeyValuePair<string, string>("settlement_bank", settlement_bank),
                new KeyValuePair<string, string>("account_number", account_number),
                new KeyValuePair<string, string>("percentage_charge", percentage_charge.ToString())
            };

            if (!string.IsNullOrWhiteSpace(primary_contact_email))
            {
                bodyKeyValues.Add(new KeyValuePair<string, string>("primary_contact_email", primary_contact_email));
            }

            if (!string.IsNullOrWhiteSpace(primary_contact_name))
            {
                bodyKeyValues.Add(new KeyValuePair<string, string>("primary_contact_name", primary_contact_name));
            }

            if (!string.IsNullOrWhiteSpace(primary_contact_phone))
            {
                bodyKeyValues.Add(new KeyValuePair<string, string>("primary_contact_phone", primary_contact_phone));
            }

            if (!string.IsNullOrWhiteSpace(settlement_schedule))
            {
                bodyKeyValues.Add(new KeyValuePair<string, string>("settlement_schedule", settlement_schedule));
            }

            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PostAsync("subaccount", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SubAccountModel>(json);
        }
        public async Task<SubAccountModel> CreateSubAccount(Dictionary<string, string> parameters)
        {
            var client = HttpConnection.CreateClient(_secretKey);

            var bodyKeyValues = parameters.ToList();
            //ensure dictionary contains paystack required parameters and your own optional parameters. metadata should be converted to json string
            
            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PostAsync("subaccount", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SubAccountModel>(json);
        }
        public async Task<SubAccountModel> FetchSubAccount(string subaccount_code)
        {
            var client = HttpConnection.CreateClient(_secretKey);

            var response = await client.GetAsync($"subaccount/{subaccount_code}");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SubAccountModel>(json);
        }

        public async Task<SubAccountListModel> ListSubAccounts()
        {
            var client = HttpConnection.CreateClient(_secretKey);

            var response = await client.GetAsync("subaccount");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SubAccountListModel>(json);
        }

       public async Task<SubAccountModel> UpdateSubAccount(string subaccount_code,string business_name = null, string settlement_bank = null, string account_number = null, float percentage_charge = 0, string primary_contact_email = null, string primary_contact_name = null, string primary_contact_phone = null, string settlement_schedule = "auto")
        {
            var client = HttpConnection.CreateClient(_secretKey);

            var bodyKeyValues = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(business_name))
            {
                bodyKeyValues.Add(new KeyValuePair<string, string>("business_name", business_name));
            }
            if (!string.IsNullOrWhiteSpace(settlement_bank))
            {
                bodyKeyValues.Add(new KeyValuePair<string, string>("settlement_bank", settlement_bank));
            }
            if (!string.IsNullOrWhiteSpace(account_number))
            {
                bodyKeyValues.Add(new KeyValuePair<string, string>("account_number", account_number));
            }
            if (percentage_charge > 0)
            {
                bodyKeyValues.Add(new KeyValuePair<string, string>("percentage_charge", percentage_charge.ToString()));
            }
            

            if (!string.IsNullOrWhiteSpace(primary_contact_email))
            {
                bodyKeyValues.Add(new KeyValuePair<string, string>("primary_contact_email", primary_contact_email));
            }

            if (!string.IsNullOrWhiteSpace(primary_contact_name))
            {
                bodyKeyValues.Add(new KeyValuePair<string, string>("primary_contact_name", primary_contact_name));
            }

            if (!string.IsNullOrWhiteSpace(primary_contact_phone))
            {
                bodyKeyValues.Add(new KeyValuePair<string, string>("primary_contact_phone", primary_contact_phone));
            }

            if (!string.IsNullOrWhiteSpace(settlement_schedule))
            {
                bodyKeyValues.Add(new KeyValuePair<string, string>("settlement_schedule", settlement_schedule));
            }

            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PutAsync($"subaccount/{subaccount_code}", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SubAccountModel>(json);
        }

        public async Task<SubAccountModel> UpdateSubAccount(Dictionary<string, string> parameters)
        {
            var client = HttpConnection.CreateClient(_secretKey);

            var bodyKeyValues = parameters.ToList();            

            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PutAsync($"subaccount/{parameters["subaccount_code"]}", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<SubAccountModel>(json);
        }


    }
}
