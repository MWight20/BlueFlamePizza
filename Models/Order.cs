using System;
using System.Collections.Generic;

namespace BlueFlamePizza.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItem = new HashSet<OrderItem>();
            Transaction = new HashSet<Transaction>();
        }

        public long OrderId { get; set; }
        public long? UserId { get; set; }
        public string OrderSessionId { get; set; }
        public string OrderToken { get; set; }
        public string OrderStatus { get; set; }
        public double OrderSubtotal { get; set; }
        public double OrderTax { get; set; }
        public double OrderGrandTotal { get; set; }
        public string OrderFirstName { get; set; }
        public string OrderLastName { get; set; }
        public string OrderPhone { get; set; }
        public string OrderEmail { get; set; }
        public string OrderCity { get; set; }
        public string OrderLine1 { get; set; }
        public string OrderLine2 { get; set; }
        public string OrderCountry { get; set; }
        public string OrderZip { get; set; }
        public DateTime OrderCreatedAt { get; set; }
        public DateTime? OrderUpdatedAt { get; set; }
        public string OrderContent { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
