using BlueFlamePizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueFlamePizza.DTOs
{
    public class CartDTO
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
        public string cart_id { get; set; }

    }
}
