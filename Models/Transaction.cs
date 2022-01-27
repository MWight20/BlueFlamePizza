using System;
using System.Collections.Generic;

namespace BlueFlamePizza.Models
{
    public partial class Transaction
    {
        public long TransactionId { get; set; }
        public long? UserId { get; set; }
        public long OrderId { get; set; }
        public string TransactionCode { get; set; }
        public string TransactionType { get; set; }
        public string TransactionMode { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime TransactionCreatedAt { get; set; }
        public DateTime? TransactionUpdatedAt { get; set; }
        public string TransactionContent { get; set; }

        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}
