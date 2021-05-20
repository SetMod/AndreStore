using Aggreagator.Models;
using Aggreagator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aggreagator.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _client;
        public CustomerService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Task<bool> AddCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerModel>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerModel> GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }
    }
}
