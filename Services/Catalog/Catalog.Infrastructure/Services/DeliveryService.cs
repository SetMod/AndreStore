using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Services
{
    public class DeliveryService : IDeliveryService
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public DeliveryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Delivery>> GetAllDeliverysAysnc()
        {
            return await _unitOfWork.deliveryRepository.GetAllAsync();
        }

        public async Task<Delivery> GetDeliveryByIdAysnc(int Id)
        {
            return await _unitOfWork.deliveryRepository.GetByIdAsync(Id);
        }

        public async Task<bool> AddDeliveryAysnc(Delivery delivery)
        {
            var res = await _unitOfWork.deliveryRepository.AddAsync(delivery);
            return res;
        }

        public async Task<bool> UpdateDeliveryAysnc(Delivery delivery)
        {
            var res = await _unitOfWork.deliveryRepository.UpdateAsync(delivery);
            return res;
        }

        public async Task<bool> DeleteDeliveryAysnc(int Id)
        {
            var res = await _unitOfWork.deliveryRepository.DeleteAsync(Id);
            return res;
        }
    }
}