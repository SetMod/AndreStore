using Catalog.Application.Interfaces;
using Catalog.Application.Models;
using Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Services
{
    public class ItemService : IItemService
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAysnc()
        {
            return await _unitOfWork.itemRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Item>> GetAllItemsPaginationAsync(ItemParameters itemParams)
        {
            return await _unitOfWork.itemRepository.GetAllItemsPaginationAsync(itemParams);
        }

        public async Task<Item> GetItemByIdAysnc(int Id)
        {
            return await _unitOfWork.itemRepository.GetByIdAsync(Id);
        }

        public async Task<bool> AddItemAysnc(Item item)
        {
            var res = await _unitOfWork.itemRepository.AddAsync(item);
            return res;
        }

        public async Task<bool> UpdateItemAysnc(Item item)
        {
            var res = await _unitOfWork.itemRepository.UpdateAsync(item);
            return res;
        }

        public async Task<bool> DeleteItemAysnc(int Id)
        {
            var res = await _unitOfWork.itemRepository.DeleteAsync(Id);
            return res;
        }
    }
}