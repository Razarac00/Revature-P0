using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Crust : AItem
    {
        private decimal _defaultPrice = 1.50m;

        public override decimal Price
        {
            get => _defaultPrice;
            set => _defaultPrice = SetupPrice(value);
        }

        public Crust(string name) : base(name)
        {
        }

    }
}