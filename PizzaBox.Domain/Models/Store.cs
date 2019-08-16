using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Store : ILocation
    {
        public string Street { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string City { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Inventory Inventory { get; set; } // dictionary<item, int>

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