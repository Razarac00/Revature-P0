using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Topping
    {
        public Topping()
        {
            PizzaToppings = new HashSet<PizzaToppings>();
        }

        public int ToppingId { get; set; }
        public string ToppingName { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<PizzaToppings> PizzaToppings { get; set; }
    }
}
