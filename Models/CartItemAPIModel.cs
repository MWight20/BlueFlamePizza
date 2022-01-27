using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueFlamePizza.Models
{
    public partial class CartItemAPIModel
    {
        public string product_id_str { get; set; }
        public string cart_id_str { get; set; }
        public string quantity_str { get; set; }
    }
}
