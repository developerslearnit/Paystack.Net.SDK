using Paystack.Net.Models.Verification;
using System.Threading.Tasks;

namespace Paystack.Net.Interfaces
{
    public interface IVerification
    {
        Task<BVNVerificationResponseModel> ResolveBVN(string bvn);
    }
}
