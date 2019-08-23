using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Order
    {
        public Order()
        {
            UserOrders = new HashSet<UserOrders>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<UserOrders> UserOrders { get; set; }
    }
}
