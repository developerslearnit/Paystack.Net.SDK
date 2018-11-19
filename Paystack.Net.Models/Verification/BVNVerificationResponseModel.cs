using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.Models.Verification
{
    public class BVNVerificationResponseModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public BVNVData data { get; set; }
        public BVNVMeta meta { get; set; }
    }

    public class BVNVMeta
    {
        public int calls_this_month { get; set; }
        public int free_calls_left { get; set; }
    }

    public class BVNVData
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string dob { get; set; }
        public string mobile { get; set; }
        public string bvn { get; set; }
    }
}
