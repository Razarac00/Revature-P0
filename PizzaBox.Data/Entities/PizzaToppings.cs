﻿using System;
using System.Collections.Generic;

namespace PizzaBox.Data.Entities
{
    public partial class PizzaToppings
    {
        public int PizzaToppingId { get; set; }
        public int PizzaId { get; set; }
        public int ToppingId { get; set; }
        public bool Active { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual Topping Topping { get; set; }
    }
}
