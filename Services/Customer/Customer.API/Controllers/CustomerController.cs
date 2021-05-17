using Customer.API.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Controllers
{
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService { get; }
        public CustomerController(ICustomerService deliveryService)
        {
            _customerService = deliveryService;
        }

        [Route("/")]
        [HttpGet]
        public string GetHello()
        {
            return "Hello from Customers!";
        }

        #region CustomerAPI
        [HttpGet]
        public async Task<IEnumerable<Entities.Customer>> GetAllCustomers()
        {
            return await _customerService.GetAllCustomersAysnc();
        }

        [HttpGet("{id}")]
        public async Task<Entities.Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerService.GetCustomerByIdAysnc(id);
        }

        [HttpPost]
        public async Task<Entities.Customer> AddCustomerAsync([FromBody] Entities.Customer item)
        {
            return await _customerService.AddCustomerAysnc(item);
        }

        [HttpPut]
        public async Task<Entities.Customer> UpdateCustomerAsync([FromBody] Entities.Customer item)
        {
            return await _customerService.UpdateCustomerAysnc(item);
        }

        [HttpDelete("{id}")]
        public async Task<Entities.Customer> DeleteCustomerAsync(int id)
        {
            return await _customerService.DeleteCustomerAysnc(id);
        }
        #endregion
    }
}
