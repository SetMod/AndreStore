using Aggregator.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aggregator.API.Services.Interfaces
{
    interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> GetAllCustomers();
        Task<CustomerModel> GetCustomer(int customerId);
        Task<bool> AddCustomer(CustomerModel customer);
        Task<bool> UpdateCustomer(CustomerModel customer);
        Task<bool> DeleteCustomer(int customerId);
    }
}
