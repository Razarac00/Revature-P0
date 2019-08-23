using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public bool Active { get; set; }
    }
}
