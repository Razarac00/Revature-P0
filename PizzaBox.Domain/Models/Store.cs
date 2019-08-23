using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Store
    {
        private Dictionary<ISellable, int> _inventory = new Inventory().Items;
        public Address Location { get; set; }
        public Dictionary<ISellable, int> Inventory { get => _inventory; set => _inventory = value; }

        public override string ToString()
        {
            return $"{this.GetType().Name} Address: {Location.AddressLine}, City: {Location.City}";
        }

        // stores make pizzas, pizzas need crust, sizes, toppings...or not
    }
}