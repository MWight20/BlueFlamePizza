using System;
using System.Collections.Generic;

namespace BlueFlamePizza.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartItem = new HashSet<CartItem>();
        }

        public long CartId { get; set; }
        public long? UserId { get; set; }
        public string CartSessionId { get; set; }
        public string CartToken { get; set; }
        public string CartStatus { get; set; }
        public string CartFirstName { get; set; }
        public string CartLastName { get; set; }
        public string CartPhone { get; set; }
        public string CartEmail { get; set; }
        public string CartCity { get; set; }
        public string CartLine1 { get; set; }
        public string CartLine2 { get; set; }
        public string CartCountry { get; set; }
        public string CartZip { get; set; }
        public DateTime CartCreatedAt { get; set; }
        public DateTime? CartUpdatedAt { get; set; }
        public string CartContent { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
    }
}
