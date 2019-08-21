using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Store : ILocation
    {
        private Dictionary<ISellable, int> _inventory = new Inventory().Items;
        public string Street { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string City { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Dictionary<ISellable, int> Inventory { get => _inventory; set => _inventory = value; } // dictionary<item, int>

        // stores make pizzas, pizzas need crust, sizes, toppings
        public Pizza MakePizza(Crust c, Size s, List<Topping> t)
        {
            return new Pizza
            {
                PizzaCrust = c,
                PizzaSize = s,
                PizzaToppings = t
            };
        }
    }
}