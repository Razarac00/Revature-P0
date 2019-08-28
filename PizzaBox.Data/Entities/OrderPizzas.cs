using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class OrderPizzas
    {
        public int UserOrderId { get; set; }
        public int PizzaId { get; set; }
        public bool Active { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual UserOrders UserOrder { get; set; }
    }
}
