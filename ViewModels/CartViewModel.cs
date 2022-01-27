using BlueFlamePizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueFlamePizza.ViewModels
{
    public class CartViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }

        public string cart_id { get; set; }

    }
}
