using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class RecentStores
    {
        public int RecentStoreId { get; set; }
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public bool Active { get; set; }

        public virtual Store Store { get; set; }
        public virtual User User { get; set; }
    }
}
