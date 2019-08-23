using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class APizza : ISellable  // The general pizza idea. The parts of the pizza but not the product
    {
        public List<Topping> Toppings { get; set; }
        public Crust Crust { get; set; }
        public Size Size { get; set; }

        public decimal Price { get => ComputePrice(); set => Price = value; }

        private decimal ComputePrice()
        {
            decimal total = 0m;
            foreach (var item in Toppings)
            {
                total += item.Price;
            }
            total += Crust.Price;
            total += Size.Price;

            return total;
        }
        public string Name { get; set; }

        protected APizza()
        {
        } 
    }
}