using Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Interfaces
{
    public interface IDeliveryService
    {
        public Task<IEnumerable<Delivery>> GetAllDeliverysAysnc();

        public Task<Delivery> GetDeliveryByIdAysnc(int Id);

        public Task<bool> AddDeliveryAysnc(Delivery delivery);

        public Task<bool> UpdateDeliveryAysnc(Delivery delivery);

        public Task<bool> DeleteDeliveryAysnc(int Id);
    }
}
