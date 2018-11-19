using Paystack.Net.Models.Customers;
using System.Threading.Tasks;

namespace Paystack.Net.Interfaces
{
    public interface ICustomers
    {
        Task<CustomerCreationResponse> CreateCustomer(string email,string firstname =null,string lastname=null, string phone = null);

        Task<CustomerCreationResponse> CreateCustomer(string email, string metadata, string phone);

        Task<CustomerListResponse> ListCustomers();
        Task<CustomerCreationResponse> FetchCustomer(int id);
    }
}
