using Paystack.Net.Models.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.Interfaces
{
    public interface ISubscriptions
    {
        Task<SubscriptionModel> CreateSubscription(string customerEmail, string planCode, string authorization,string start_date);
    }
}
