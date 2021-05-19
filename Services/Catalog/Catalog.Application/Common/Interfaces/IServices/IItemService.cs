using Catalog.Application.Models;
using Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Interfaces
{
    public interface IItemService
    {
        public Task<IEnumerable<Item>> GetAllItemsAysnc();

        public Task<IEnumerable<Item>> GetAllItemsPaginationAsync(ItemParameters itemParams);

        public Task<Item> GetItemByIdAysnc(int Id);

        public Task<bool> AddItemAysnc(Item item);

        public Task<bool> UpdateItemAysnc(Item item);

        public Task<bool> DeleteItemAysnc(int Id);
    }
}
