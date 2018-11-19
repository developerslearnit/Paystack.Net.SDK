using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.Models.Charge
{
    public class ChargeResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public ChargeData data { get; set; }
    }

    public class ChargeCustomer
    {
        public int id { get; set; }
        public object first_name { get; set; }
        public object last_name { get; set; }
        public string email { get; set; }
        public string customer_code { get; set; }
        public object phone { get; set; }
        public object metadata { get; set; }
        public string risk_action { get; set; }
    }

    public class ChargeData
    {
        public int amount { get; set; }
        public string currency { get; set; }
        public DateTime transaction_date { get; set; }
        public string status { get; set; }
        public string reference { get; set; }
        public string domain { get; set; }
        public ChargeMetadata metadata { get; set; }
        public string gateway_response { get; set; }
        public object message { get; set; }
        public string channel { get; set; }
        public string ip_address { get; set; }
        public object log { get; set; }
        public int fees { get; set; }
        public ChargeAuthorization authorization { get; set; }
        public ChargeCustomer customer { get; set; }
        public object plan { get; set; }
    }

    public class ChargeMetadata
    {
        public List<CustomField> custom_fields { get; set; }
    }


    public class ChargeAuthorization
    {
        public string authorization_code { get; set; }
        public string bin { get; set; }
        public string last4 { get; set; }
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public string channel { get; set; }
        public string card_type { get; set; }
        public string bank { get; set; }
        public string country_code { get; set; }
        public string brand { get; set; }
        public bool reusable { get; set; }
        public string signature { get; set; }
    }

    public class CustomField
    {
        public string display_name { get; set; }
        public string variable_name { get; set; }
        public string value { get; set; }
    }
}
