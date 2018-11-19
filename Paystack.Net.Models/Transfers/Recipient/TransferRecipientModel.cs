using System;
using System.Collections.Generic;

namespace Paystack.Net.Models.Transfers.Recipient
{
    public class TransferRecipientModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class TransferRecipientListModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Data> data { get; set; }
    }

    public class Metadata
    {
        public string job { get; set; }
    }

    public class Details
    {
        public string account_number { get; set; }
        public object account_name { get; set; }
        public string bank_code { get; set; }
        public string bank_name { get; set; }
    }

    public class Data
    {
        public string type { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Metadata metadata { get; set; }
        public string domain { get; set; }
        public Details details { get; set; }
        public string currency { get; set; }
        public string recipient_code { get; set; }
        public bool active { get; set; }
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
