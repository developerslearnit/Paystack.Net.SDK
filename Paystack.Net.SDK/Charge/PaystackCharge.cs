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
using System.Net.Http.Headers;

namespace Paystack.Net.SDK.Charge
{
    public class PaystackCharge : ICharge
    {
        private string _secretKey;
        public PaystackCharge(string secretKey)
        {
            this._secretKey = secretKey;
        }

       


        public async Task<ChargeResponseModel> ChargeCard(string email, string amount, string pin, string cvv,
            string expiry_month, string expiry_year, string number, string display_name = null, string value = null,
            string variable_name = null)
        {
            var client = HttpConnection.CreateClient(this._secretKey);

            var model = new ChargeCardInputModel()
            {
                amount = amount,
                card = new ChargeCard()
                {
                    cvv = cvv,
                    expiry_month = expiry_month,
                    expiry_year = expiry_year,
                    number = number
                },
                email = email,
                pin = pin
            };

            if (!string.IsNullOrWhiteSpace(display_name))
            {
                var _metadata = new ChargeCardMetadata()
                {
                    custom_fields = new List<Custom_Field>()
                    {
                        new Custom_Field()
                        {
                            display_name = display_name,
                            value=value,
                            variable_name = variable_name
                        }
                    }
                };

                model.metadata = _metadata;
            }

           
            var jsonObj = JsonConvert.SerializeObject(model);            
            var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("charge", content);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ChargeResponseModel>(json);
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


        public async Task<ChargeResponseModel> ChargeAuthorization(string amount, string email, string pin, string authorization_code,
            string display_name = null, string value = null,
            string variable_name = null)
        {
            var client = HttpConnection.CreateClient(this._secretKey);

            var model = new ChargeAuthorizationInputModel()
            {
                amount = amount,
                email = email,
                pin = pin,
                authorization_code = authorization_code
            };
            if (!string.IsNullOrWhiteSpace(display_name))
            {
                var _meta = new Metadata()
                {
                    custom_fields = new List<ChargeAuthCustomField>()
                    {
                        //Capacity = 
                        //display_name = display_name,
                        //value = value,
                        //variable_name = variable_name
                    }
                };
            }


            var jsonObj = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("charge", content);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ChargeResponseModel>(json);
        }

        public async Task<ChargeResponseModel> ChargeAuthorization(ChargeAuthorizationInputModel model)
        {
            var client = HttpConnection.CreateClient(this._secretKey);


            var jsonObj = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("charge", content);

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ChargeResponseModel>(json);
        }

        public async Task<ChargeResponseModel> ChargeCard(ChargeAuthorizationInputModel model)
        {
            var client = HttpConnection.CreateClient(this._secretKey);

            
            var jsonObj = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonObj, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("charge", content);

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
