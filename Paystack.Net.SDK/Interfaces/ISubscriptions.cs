using Paystack.Net.SDK.Models.Subscription;
using System.Threading.Tasks;

namespace Paystack.Net.SDK
{
    public interface ISubscriptions
    {
        Task<SubscriptionModel> CreateSubscription(string customerEmail, string planCode, string authorization,string start_date);
    }
}
