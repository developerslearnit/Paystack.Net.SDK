using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.SDK.Models.Subaccounts.CreateSubAccount
{
    public class SubAccountModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class SubAccountListModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Data> data { get; set; }
    }

    public class Data
    {
        public int integration { get; set; }
        public string domain { get; set; }
        public string subaccount_code { get; set; }
        public string business_name { get; set; }
        public object description { get; set; }
        public object primary_contact_name { get; set; }
        public object primary_contact_email { get; set; }
        public object primary_contact_phone { get; set; }
        public object metadata { get; set; }
        public double percentage_charge { get; set; }
        public bool is_verified { get; set; }
        public string settlement_bank { get; set; }
        public string account_number { get; set; }
        public string settlement_schedule { get; set; }
        public bool active { get; set; }
        public bool migrate { get; set; }
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
