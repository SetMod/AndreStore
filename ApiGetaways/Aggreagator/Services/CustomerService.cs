using Aggregator.API.Models;
using Aggregator.API.Services.Interfaces;
using Aggregator.API.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aggregator.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _client;
        public CustomerService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomers()
        {
            var response = await _client.GetAsync($"/Profile");
            return await response.ReadContentAs<IEnumerable<CustomerModel>>();
        }

        public async Task<CustomerModel> GetCustomer(int customerId)
        {
            var response = await _client.GetAsync($"/Profile");
            return await response.ReadContentAs<CustomerModel>();
        }

        public async Task<bool> AddCustomer(CustomerModel customer)
        {
            var response = await _client.GetAsync($"/Profile");
            return await response.ReadContentAs<bool>();
        }
        public async Task<bool> UpdateCustomer(CustomerModel customer)
        {
            var response = await _client.GetAsync($"/Profile");
            return await response.ReadContentAs<bool>();
        }

        public async Task<bool> DeleteCustomer(int customerId)
        {
            var response = await _client.GetAsync($"/Profile");
            return await response.ReadContentAs<bool>();
        }

    }
}
