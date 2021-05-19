using Catalog.Application.Models;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Interfaces
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        public Task<IEnumerable<Item>> GetAllItemsPaginationAsync(ItemParameters itemParams);
    }
}
