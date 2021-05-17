using Customer.API.Interfaces;
using Customer.API.Interfaces.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.API.Services
{
    public class CustomerService : ICustomerService
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Entities.Customer>> GetAllCustomersAysnc()
        {
            return await _unitOfWork.customerRepository.GetAllAsync();
        }

        public async Task<Entities.Customer> GetCustomerByIdAysnc(int Id)
        {
            return await _unitOfWork.customerRepository.GetByIdAsync(Id);
        }

        public async Task<Entities.Customer> AddCustomerAysnc(Entities.Customer customer)
        {
            var res = await _unitOfWork.customerRepository.AddAsync(customer);
            //_unitOfWork.CustomerRepo.SaveChangesAsync();
            return res;
        }

        public async Task<Entities.Customer> UpdateCustomerAysnc(Entities.Customer customer)
        {
            var res = await _unitOfWork.customerRepository.UpdateAsync(customer);
            //_unitOfWork.CustomerRepo.SaveChangesAsync();
            return res;
        }

        public async Task<Entities.Customer> DeleteCustomerAysnc(int Id)
        {
            var res = await _unitOfWork.customerRepository.DeleteAsync(Id);
            //_unitOfWork.CustomerRepo.SaveChangesAsync();
            return res;
        }
    }
}