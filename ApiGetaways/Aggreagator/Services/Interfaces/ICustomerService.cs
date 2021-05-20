using Aggreagator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggreagator.Services.Interfaces
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
