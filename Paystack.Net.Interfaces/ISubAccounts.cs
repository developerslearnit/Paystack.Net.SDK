using Paystack.Net.Models.Subaccounts.CreateSubAccount;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paystack.Net.Interfaces
{
    public interface ISubAccounts
    {
        Task<SubAccountModel> CreateSubAccount(string business_name,string settlement_bank,string account_number,float percentage_charge,
            string primary_contact_email=null,string primary_contact_name=null,string primary_contact_phone=null,string settlement_schedule="auto");

        Task<SubAccountModel> UpdateSubAccount(string subaccount_code,string business_name=null, string settlement_bank = null, string account_number = null, 
            float percentage_charge = 0,
            string primary_contact_email = null, string primary_contact_name = null, string primary_contact_phone = null, string settlement_schedule = "auto");

        Task<SubAccountModel> CreateSubAccount(Dictionary<string, string> parameters);
        Task<SubAccountModel> UpdateSubAccount(Dictionary<string, string> parameters);
        Task<SubAccountModel> FetchSubAccount(string subaccount_code);

        Task<SubAccountListModel> ListSubAccounts();
    }
}
