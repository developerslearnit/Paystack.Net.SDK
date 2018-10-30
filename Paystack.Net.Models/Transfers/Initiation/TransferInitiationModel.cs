using System;

namespace Paystack.Net.Models.Transfers.Initiation
{
    public class TransferInitiationModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public int integration { get; set; }
        public string domain { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public string source { get; set; }
        public string reason { get; set; }
        public int recipient { get; set; }
        public string status { get; set; }
        public string transfer_code { get; set; }
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
