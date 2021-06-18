using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.SDK.Models.Subscription
{
    public class SubscriptionModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public int customer { get; set; }
        public int plan { get; set; }
        public int integration { get; set; }
        public string domain { get; set; }
        public int start { get; set; }
        public string status { get; set; }
        public int quantity { get; set; }
        public int amount { get; set; }
        public int authorization { get; set; }
        public string subscription_code { get; set; }
        public string email_token { get; set; }
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
