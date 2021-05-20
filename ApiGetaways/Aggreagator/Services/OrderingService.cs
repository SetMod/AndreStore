using Aggregator.API.Models;
using Aggregator.API.Services.Interfaces;
using Aggregator.API.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aggregator.API.Services
{
    public class OrderingService : IOrderingService
    {

        private readonly HttpClient _client;

        public OrderingService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<bool> AddOrder(int customerId, OrdersModel order)
        {
            var response = await _client.GetAsync($"/Ordering/{customerId}");
            return await response.ReadContentAs<bool>();
        }

        public async Task<bool> DeleteOrder(int customerId, int orderId)
        {
            var response = await _client.GetAsync($"/Ordering/{customerId}");
            return await response.ReadContentAs<bool>();
        }

        public async Task<OrdersModel> GetOrder(int customerId, int orderId)
        {
            var response = await _client.GetAsync($"/Ordering/{customerId}");
            return await response.ReadContentAs<OrdersModel>();
        }

        public async Task<IEnumerable<OrdersModel>> GetOrders(int customerId)
        {
            var response = await _client.GetAsync($"/Ordering/{customerId}");
            return await response.ReadContentAs<List<OrdersModel>>();
        }

        public async Task<bool> UpdateOrder(int customerId, OrdersModel order)
        {
            var response = await _client.GetAsync($"/Ordering/{customerId}");
            return await response.ReadContentAs<bool>();
        }
    }
}
