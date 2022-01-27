using System;
using System.Collections.Generic;

namespace BlueFlamePizza.Models
{
    public partial class User
    {
        public User()
        {
            Cart = new HashSet<Cart>();
            Order = new HashSet<Order>();
            Transaction = new HashSet<Transaction>();
        }

        public long UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
        public string UserPasswordHash { get; set; }
        public long UserRoleId { get; set; }
        public DateTime UserRegisteredAt { get; set; }
        public DateTime? UserLastLogin { get; set; }
        public string UserPasswordHint { get; set; }
        public string UserSessionId { get; set; }

        public virtual Role UserRole { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
