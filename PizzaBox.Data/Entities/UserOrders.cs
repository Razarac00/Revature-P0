using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class UserOrders
    {
        public UserOrders()
        {
            OrderPizzas = new HashSet<OrderPizzas>();
        }

        public int UserOrderId { get; set; }
        public int UserId { get; set; }
        public bool Active { get; set; }
        public int AddressId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Address Address { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderPizzas> OrderPizzas { get; set; }
    }
}
