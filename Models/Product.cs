using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlueFlamePizza.Models
{
    public partial class Product
    {
        public Product()
        {
            CartItem = new HashSet<CartItem>();
            OrderItem = new HashSet<OrderItem>();
        }

        public long ProductId { get; set; }
        public long CategoryId { get; set; }
        public string ProductTitle { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double ProductPrice { get; set; }
        public short ProductQuantity { get; set; }
        public DateTime? ProductCreatedAt { get; set; }
        public string ProductContent { get; set; }
        public string ProductSku { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
