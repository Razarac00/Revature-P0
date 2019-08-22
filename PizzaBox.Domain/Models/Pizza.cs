using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Pizza : APizza
    {
        private List<Topping> _toppings;

        public List<Topping> GetPizzaToppings()
        {
            throw new NotImplementedException();
        }

        public void AddTopping(List<Topping> toppingList)
        {
            // _toppings
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