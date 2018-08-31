using Paystack.Net.Models.Charge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.Interfaces
{
    public interface ICharge
    {
        Task<ChargeResponseModel> ChargeCard(ChargeCardInputModel model);

        Task<ChargeResponseModel> ChargeCard(ChargeAuthorizationInputModel model);

        Task<ChargeResponseModel> SubmitPin(string pin, string reference);

        Task<ChargeResponseModel> SubmitOTP(string otp, string reference);

        Task<ChargeResponseModel> CheckPendingCharge(string reference);
    }
}
