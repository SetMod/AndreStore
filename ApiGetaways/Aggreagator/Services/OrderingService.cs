﻿using Aggreagator.Models;
using Aggreagator.Extensions;
using Aggreagator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aggreagator.Services
{
    public class OrderingService : IOrderingService
    {

        private readonly HttpClient _client;

        public OrderingService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Task<bool> AddOrder(int customerId, OrdersModel order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrder(int customerId, int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<OrdersModel> GetOrder(int customerId, int orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrdersModel>> GetOrders(int customerId)
        {
            var response = await _client.GetAsync($"/Ordering/{customerId}");
            return await response.ReadContentAs<List<OrdersModel>>();
        }

        public Task<bool> UpdateOrder(int customerId, OrdersModel order)
        {
            throw new NotImplementedException();
        }
    }
}
