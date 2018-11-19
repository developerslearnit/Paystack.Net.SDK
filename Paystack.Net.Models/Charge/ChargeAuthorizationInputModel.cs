using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.Models.Charge
{
    public class ChargeAuthorizationInputModel
    {
        public string email { get; set; }
        public string amount { get; set; }
        public Metadata metadata { get; set; }
        public string authorization_code { get; set; }
        public string pin { get; set; }
    }

    public class ChargeAuthCustomField
    {
        public string value { get; set; }
        public string display_name { get; set; }
        public string variable_name { get; set; }
    }

    public class Metadata
    {
        public List<ChargeAuthCustomField> custom_fields { get; set; }
    }
}
