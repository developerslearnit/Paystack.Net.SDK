using Paystack.Net.Interfaces;
using Paystack.Net.Models.Charge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paystack.Net.SDK.HttpExtension;
using System.Net.Http;
using Newtonsoft.Json;

namespace Paystack.Net.SDK.Charge
{
    public class PaystackCharge : ICharge
    {
        private string _secretKey;
        public PaystackCharge(string secretKey)
        {
            this._secretKey = secretKey;
        }

        public async Task<ChargeResponseModel> ChargeCard(ChargeCardInputModel model)
        {
            var client = HttpConnection.CreateClient(this._secretKey);

            var bodyKeyValues = model.ToKeyValue();

            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PostAsync("charge", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ChargeResponseModel>(json);
        }

        public async Task<ChargeResponseModel> ChargeCard(ChargeAuthorizationInputModel model)
        {
            var client = HttpConnection.CreateClient(this._secretKey);

            var bodyKeyValues = model.ToKeyValue();

            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PostAsync("charge", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ChargeResponseModel>(json);
        }

        public async Task<ChargeResponseModel> CheckPendingCharge(string reference)
        {
            var client = HttpConnection.CreateClient(this._secretKey);

            var response = await client.GetAsync($"charge/{reference}");

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ChargeResponseModel>(json);
        }

        public async Task<ChargeResponseModel> SubmitOTP(string otp, string reference)
        {
            var client = HttpConnection.CreateClient(this._secretKey);

            var bodyKeyValues = new List<KeyValuePair<string, string>>();

            bodyKeyValues.Add(new KeyValuePair<string, string>("otp", otp));
            bodyKeyValues.Add(new KeyValuePair<string, string>("reference", reference));

            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PostAsync("charge/submit_otp", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ChargeResponseModel>(json);
        }

        public async Task<ChargeResponseModel> SubmitPin(string pin, string reference)
        {
            var client = HttpConnection.CreateClient(this._secretKey);

            var bodyKeyValues = new List<KeyValuePair<string, string>>();

            bodyKeyValues.Add(new KeyValuePair<string, string>("pin", pin));
            bodyKeyValues.Add(new KeyValuePair<string, string>("reference", reference));

            var formContent = new FormUrlEncodedContent(bodyKeyValues);

            var response = await client.PostAsync("charge/submit_pin", formContent);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ChargeResponseModel>(json);
        }
    }
}
