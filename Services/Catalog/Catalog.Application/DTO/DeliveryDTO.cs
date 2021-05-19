using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Application.DTO
{
    public class DeliveryDTO
    {
        public int Id { get; set; }
        public string DeliveryType { get; set; }
        public decimal Price { get; set; }
        public int DeliveryTime { get; set; }
    }
}
