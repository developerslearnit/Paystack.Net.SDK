using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.Models.Charge
{
    public class ChargeCardInputModel
    {
        public string email { get; set; }
        public string amount { get; set; }
        public ChargeCardMetadata metadata { get; set; }
        public ChargeCard card { get; set; }
        public string pin { get; set; }
    }

    public class Custom_Field
    {
        public string value { get; set; }
        public string display_name { get; set; }
        public string variable_name { get; set; }
    }

    public class ChargeCardMetadata
    {
        public List<Custom_Field> custom_fields { get; set; }
    }

    public class ChargeCard
    {
        public string cvv { get; set; }
        public string number { get; set; }
        public string expiry_month { get; set; }
        public string expiry_year { get; set; }
    }
}
