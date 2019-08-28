using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Address
    {
        public Address()
        {
            CrustInventory = new HashSet<CrustInventory>();
            ToppingInventory = new HashSet<ToppingInventory>();
            UserOrders = new HashSet<UserOrders>();
        }

        public int AddressId { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<CrustInventory> CrustInventory { get; set; }
        public virtual ICollection<ToppingInventory> ToppingInventory { get; set; }
        public virtual ICollection<UserOrders> UserOrders { get; set; }
    }
}
