using System;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Pizza : ISellable
    {
        public List<Topping> PizzaToppings { get; set; }
        public Crust PizzaCrust { get; set; }
        public Size PizzaSize { get; set; }

        public decimal Price { get; set; }
        public string Name { get; set; }

        public int GetPizzaSize()
        {
            throw new NotImplementedException();
        }

        private decimal ComputePizzaPrice()
        {
            //throw new NotImplementedException();
            decimal total = 0m;
            foreach (var toppin in PizzaToppings)
            {
                total += toppin.Price;
            }

            total += PizzaCrust.Price;
            total += PizzaSize.Price;

            return total;
        }

        public List<Topping> GetPizzaToppings()
        {
            throw new NotImplementedException();
        }

        public void AddTopping(List<Topping> toppingList)
        {
            throw new NotImplementedException();
        }

        public Action AddTopping(Topping topping)
        {
            throw new NotImplementedException();
        }

        public Crust getPizzaCrust()
        {
            throw new NotImplementedException();
        }
    }
}