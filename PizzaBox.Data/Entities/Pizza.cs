using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaToppings = new HashSet<PizzaToppings>();
        }

        public int PizzaId { get; set; }
        public int SizeId { get; set; }
        public int CrustId { get; set; }
        public bool Active { get; set; }

        public virtual Crust Crust { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<PizzaToppings> PizzaToppings { get; set; }
    }
}
