using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aggregator.API.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public int TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public List<CartItemModel> Items { get; set; }
    }
}
