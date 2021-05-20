using Aggregator.API.Models;
using Aggregator.API.Services.Interfaces;
using Aggregator.API.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aggregator.API.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;
        public CatalogService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ItemsModel>> GetCatalog()
        {
            var response = await _client.GetAsync($"/Items");
            return await response.ReadContentAs<IEnumerable<ItemsModel>>();
        }

        public async Task<ItemsModel> GetCatalogItem(int itemId)
        {
            var response = await _client.GetAsync($"/Items/{itemId}");
            return await response.ReadContentAs<ItemsModel>();
        }

        public async Task<bool> AddCatalogItem(ItemsModel item)
        {
            var response = await _client.GetAsync($"/Items");
            return await response.ReadContentAs<bool>();
        }
        public async Task<bool> UpdateCatalogItem(ItemsModel item)
        {
            var response = await _client.GetAsync($"/Items");
            return await response.ReadContentAs<bool>();
        }

        public async Task<bool> DeleteCatalogItem(int itemId)
        {
            var response = await _client.GetAsync($"/Items/{itemId}");
            return await response.ReadContentAs<bool>();
        }

    }
}
