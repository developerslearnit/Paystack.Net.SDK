using System;
using System.Collections.Generic;
using System.Text;

namespace Paystack.Net.SDK
{
    public interface IChargeHelper
    {
        int AddCharge(int amountInKobo);
        decimal CalculatedCharge(int amountInKobo);
    }
}
