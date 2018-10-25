using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.SDK.Fees
{
    public static class ChargeHelper
    {
        static PaystackFee paystackFee = new PaystackFee();

        public static int AddCharge(int amountInKobo)
        {            
            return paystackFee.AddCharge(amountInKobo);
        }

        public static decimal CalculatedCharge(int amountInKobo)
        {
            var amountWithCharge = paystackFee.AddCharge(amountInKobo);
            return ((amountWithCharge - amountInKobo) / 100);
        }

        
    }
}
