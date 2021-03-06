using AutoMapper;
using Customer.API.DTO;
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
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService deliveryService, IMapper mapper)
        {
            _customerService = deliveryService;
            _mapper = mapper;
        }

        [Route("/")]
        [HttpGet]
        public string GetHello()
        {
            return "Hello from Customers!";
        }

        #region CustomerAPI
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var res = await _customerService.GetAllCustomersAysnc();
            var resDto = _mapper.Map<IEnumerable<CustomerDTO>>(res);
            return Ok(resDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerByIdAsync(int id)
        {
            var res = await _customerService.GetCustomerByIdAysnc(id);
            var resDto = _mapper.Map<CustomerDTO>(res);
            if (res == null)
            {
                return NotFound(resDto);
            }
            return Ok(resDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync([FromBody] CustomerDTO itemDTO)
        {
            var item = _mapper.Map<Entities.Customer>(itemDTO);
            var res = await _customerService.AddCustomerAysnc(item);
            if (res == null)
            {
                return BadRequest(res);
            }
            var resDto = _mapper.Map<CustomerDTO>(res);
            return Ok(resDto);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] CustomerDTO customerDTO)
        {
            var customers = await _customerService.GetAllCustomersAysnc();
            var customer = customers.First(customer => customer.Email == customerDTO.Email);

            if (customer == null) return BadRequest("User not found");
            if (customer.Password != customerDTO.Password) return BadRequest("Wrong password");

            return Ok(customer);
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> SignUp([FromBody] CustomerDTO customerDTO)
        {
            var customers = await _customerService.GetAllCustomersAysnc();
            var customerExists = customers.FirstOrDefault(customer => customer.Email == customerDTO.Email);

            if (customerExists != null) return BadRequest("User already exists");

            var customer = _mapper.Map<Entities.Customer>(customerDTO);
            var res = await _customerService.AddCustomerAysnc(customer);

            if (res == null) return BadRequest(res);

            return Ok(true);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] CustomerDTO itemDTO)
        {
            var item = _mapper.Map<Entities.Customer>(itemDTO);
            var res = await _customerService.UpdateCustomerAysnc(item);
            if (res == null)
            {
                return BadRequest(res);
            }
            var resDto = _mapper.Map<CustomerDTO>(res);
            return Ok(resDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            var res = await _customerService.DeleteCustomerAysnc(id);
            if (res == null)
            {
                return NotFound(res);
            }
            var resDto = _mapper.Map<CustomerDTO>(res);
            return Ok(resDto);
        }
        #endregion
    }
}
