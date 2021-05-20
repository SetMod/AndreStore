using Aggreagator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggreagator.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<IEnumerable<ItemsModel>> GetCatalog();
        Task<ItemsModel> GetCatalogItem(int itemId);
        Task<bool> AddCatalogItem(ItemsModel item);
        Task<bool> UpdateCatalogItem(ItemsModel item);
        Task<bool> DeleteCatalogItem(int itemId);
    }
}
