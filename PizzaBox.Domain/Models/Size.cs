using System;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Size : ISellable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}