using Paystack.Net.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Net.Interfaces
{
    public interface ICustomers
    {
        Task<CustomerCreationResponse> CreateCustomer(string email,string firstname =null,string lastname=null, string phone = null);

        Task<CustomerListResponse> ListCustomers();
        Task<CustomerCreationResponse> FetchCustomer(int id);
    }
}
