using System;
using System.Collections.Generic;

namespace BlueFlamePizza.Models
{
    public partial class OrderItem
    {
        public long OrderItemId { get; set; }
        public long ProductId { get; set; }
        public long OrderId { get; set; }
        public double OrderItemPrice { get; set; }
        public short OrderItemQuantity { get; set; }
        public DateTime OrderItemCreatedAt { get; set; }
        public DateTime? OrderItemUpdatedAt { get; set; }
        public string OrderItemSku { get; set; }
        public string OrderItemContent { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
