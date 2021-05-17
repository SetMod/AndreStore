using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.API.Interfaces.IServices
{
    public interface ICustomerService
    {
        public Task<IEnumerable<Entities.Customer>> GetAllCustomersAysnc();

        public Task<Entities.Customer> GetCustomerByIdAysnc(int Id);

        public Task<Entities.Customer> AddCustomerAysnc(Entities.Customer customer);

        public Task<Entities.Customer> UpdateCustomerAysnc(Entities.Customer customer);

        public Task<Entities.Customer> DeleteCustomerAysnc(int Id);
    }
}
