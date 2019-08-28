using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class ToppingInventory
    {
        public int AddressId { get; set; }
        public int ToppingId { get; set; }
        public bool Active { get; set; }

        public virtual Address Address { get; set; }
        public virtual Topping Topping { get; set; }
    }
}
