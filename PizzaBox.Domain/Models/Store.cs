using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Store : ILocation
    {
        private Dictionary<ISellable, int> _inventory = new Inventory().Items;
        public string Street { get; set; }
        public string City { get; set; }
        public Dictionary<ISellable, int> Inventory { get => _inventory; set => _inventory = value; } // dictionary<item, int>

        // stores make pizzas, pizzas need crust, sizes, toppings...or not
    }
}