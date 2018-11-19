using Paystack.Net.Models.Verification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.Interfaces
{
    public interface IVerification
    {
        Task<BVNVerificationResponseModel> ResolveBVN(string bvn);
    }
}
