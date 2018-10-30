using System;
using System.Collections.Generic;

namespace Paystack.Net.Models.Customers
{

    public class CustomerListResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public  List<Data> data { get; set; }
    }


    public class CustomerCreationResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Photo
    {
        public string type { get; set; }
        public string typeId { get; set; }
        public string typeName { get; set; }
        public string url { get; set; }
        public bool isPrimary { get; set; }
    }

    public class Metadata
    {
        public List<Photo> photos { get; set; }
    }

    public class Data
    {
        public int integration { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public object phone { get; set; }
        public Metadata metadata { get; set; }
        public string domain { get; set; }
        public string customer_code { get; set; }
        public string risk_action { get; set; }
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
