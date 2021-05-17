using Aggreagator.Models;
using Aggreagator.Extensions;
using Aggreagator.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aggreagator.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _client;

        public CartService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CartModel> GetCart(int customerId)
        {
            var response = await _client.GetAsync($"/Cart/{customerId}");
            return await response.ReadContentAs<CartModel>();
        }
    }
}
