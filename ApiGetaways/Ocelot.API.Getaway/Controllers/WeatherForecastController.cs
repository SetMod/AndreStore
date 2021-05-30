using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocelot.API.Getaway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string[] Get()
        {
            string[] list =
            {
                "Hello from Ocelot API",
                "Catalog - https://localhost:8001/swagger",
                "Cart - https://localhost:8003/swagger",
                "Orders - https://localhost:8005/swagger",
                "Customer - https://localhost:8007/swagger",
                "Aggregator - https://localhost:5051/swagger",
            };
            return list;
        }
    }
}
