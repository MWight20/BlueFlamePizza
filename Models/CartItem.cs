using System;
using System.Collections.Generic;

namespace BlueFlamePizza.Models
{
    public partial class CartItem
    {
        public long CartItemId { get; set; }
        public long ProductId { get; set; }
        public long CartId { get; set; }
        public double CartItemPrice { get; set; }
        public short CartItemQuantity { get; set; }
        public DateTime CartItemCreatedAt { get; set; }
        public DateTime? CartItemUpdatedAt { get; set; }
        public string CartItemContent { get; set; }
        public byte CartItemActive { get; set; }
        public string CartItemSku { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
