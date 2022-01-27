using BlueFlamePizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueFlamePizza.ViewModels
{
    public class OrderViewModel
    {
        public Order Orders { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }

    }
}
