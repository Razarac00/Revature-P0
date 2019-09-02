using System;
using System.Collections.Generic;
//using PizzaBox.Data.Entities;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Crust : AItem
    {
        public int CrustId { get; set; }
        private decimal _defaultPrice = 1.50m;
        public override decimal Price
        {
            get => _defaultPrice;
            set => _defaultPrice = SetupPrice(value);
        }

        public Crust(string name) : base(name)
        {
        }

        public Crust(string name, decimal price) : base(name, price)
        {}

    }
}