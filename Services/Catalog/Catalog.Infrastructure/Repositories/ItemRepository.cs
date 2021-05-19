using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Catalog.Application.Interfaces.IMongo;
using System.Threading.Tasks;
using System.Collections;
using Catalog.Application.Helpers;
using Catalog.Application.Models;

namespace Catalog.Infrastructure.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(IMongoDBSettings settings) : base(settings)
        {
            settings.CollectionName = "Item";
        }
        public async Task<IEnumerable<Item>> GetAllItemsPaginationAsync(ItemParameters itemParams)
        {
            var res = await GetAllAsync();
            return PagedList<Item>.ToPagedList(res,
                itemParams.PageNumber,
                itemParams.PageSize);
        }
    }
}
