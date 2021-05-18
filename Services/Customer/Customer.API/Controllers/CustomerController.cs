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
        public async Task<IActionResult> GetAllCustomers()
        {
            var res = await _customerService.GetAllCustomersAysnc();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerByIdAsync(int id)
        {
            var res = await _customerService.GetCustomerByIdAysnc(id);
            if (res == null)
            {
                return NotFound(res);
            }
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync([FromBody] Entities.Customer item)
        {
            var res = await _customerService.AddCustomerAysnc(item);
            if (res == null)
            {
                return BadRequest(res);
            }
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var loactionUri = baseUrl + "/" + res.Id.ToString();
            return Created(loactionUri, res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] Entities.Customer item)
        {
            return Ok(await _customerService.UpdateCustomerAysnc(item));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            var res = await _customerService.DeleteCustomerAysnc(id);
            if (res == null)
            {
                return NotFound(res);
            }
            return Ok(res);
        }
        #endregion
    }
}
