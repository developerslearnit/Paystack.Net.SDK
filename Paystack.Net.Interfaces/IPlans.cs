using Paystack.Net.Models.Plans;
using System.Threading.Tasks;

namespace Paystack.Net.Interfaces
{
    public interface IPlans
    {
        Task<PlansModel> CreatePlan(string name, string description, int amount, string interval,bool send_invoices =false,
            bool send_sms=false, string currency = "NGN",int invoice_limit =0);

        Task<PlanListModel> ListPlans();

        Task<FetchPlanModel> FetchPlans(string plan_code);
    }
}
