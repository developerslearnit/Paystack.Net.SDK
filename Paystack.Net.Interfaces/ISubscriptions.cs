using Paystack.Net.Models.Subscription;
using System.Threading.Tasks;

namespace Paystack.Net.Interfaces
{
    public interface ISubscriptions
    {
        Task<SubscriptionModel> CreateSubscription(string customerEmail, string planCode, string authorization,string start_date);
    }
}
