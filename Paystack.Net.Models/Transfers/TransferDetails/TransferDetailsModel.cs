using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.Models.Transfers.TransferDetails
{
    public class TransferDetailsModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }


    public class TransferDetailsListModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public List<Data> data { get; set; }
    }

    public class Details
    {
        public string account_number { get; set; }
        public object account_name { get; set; }
        public string bank_code { get; set; }
        public string bank_name { get; set; }
    }

    public class Recipient
    {
        public string domain { get; set; }
        public string type { get; set; }
        public string currency { get; set; }
        public string name { get; set; }
        public Details details { get; set; }
        public object metadata { get; set; }
        public string recipient_code { get; set; }
        public bool active { get; set; }
        public int id { get; set; }
        public int integration { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public class Data
    {
        public Recipient recipient { get; set; }
        public string domain { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public string source { get; set; }
        public object source_details { get; set; }
        public string reason { get; set; }
        public string status { get; set; }
        public object failures { get; set; }
        public string transfer_code { get; set; }
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
