using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Store
    {
        public Store()
        {
            RecentStores = new HashSet<RecentStores>();
        }

        public int StoreId { get; set; }
        public int AddressId { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<RecentStores> RecentStores { get; set; }
    }
}
