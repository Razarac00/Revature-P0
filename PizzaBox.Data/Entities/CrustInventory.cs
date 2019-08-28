using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class CrustInventory
    {
        public int AddressId { get; set; }
        public int CrustId { get; set; }
        public bool Active { get; set; }

        public virtual Address Address { get; set; }
        public virtual Crust Crust { get; set; }
    }
}
