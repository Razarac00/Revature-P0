using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class User
    {
        public User()
        {
            UserOrders = new HashSet<UserOrders>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<UserOrders> UserOrders { get; set; }
    }
}
