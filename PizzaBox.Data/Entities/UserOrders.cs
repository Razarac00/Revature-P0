using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class UserOrders
    {
        public int UserOrderId { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public bool Active { get; set; }

        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
    }
}
