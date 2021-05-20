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
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;
        public CatalogService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Task<bool> AddCatalogItem(ItemsModel item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCatalogItem(int itemId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ItemsModel>> GetCatalog()
        {
            var response = await _client.GetAsync($"/Catalog");
            return await response.ReadContentAs<List<ItemsModel>>();
        }

        public Task<ItemsModel> GetCatalogItem(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCatalogItem(ItemsModel item)
        {
            throw new NotImplementedException();
        }
    }
}
