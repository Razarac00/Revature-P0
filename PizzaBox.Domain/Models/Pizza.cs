using System;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Pizza : ISellable
    {
        public List<Topping> PizzaToppings { get; private set; }

        public Crust PizzaCrust { get; set; }

        public double Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int GetPizzaSize()
        {
            throw new NotImplementedException();
        }

        private double ComputePizzaPrice()
        {
            //throw new NotImplementedException();
            double total = 0.0;
            foreach (var toppin in PizzaToppings)
            {
                total += toppin.Price;
            }

            total += PizzaCrust.Price;

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