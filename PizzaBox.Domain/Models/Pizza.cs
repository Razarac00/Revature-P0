using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class Pizza
    {
        public int GetPizzaSize()
        {
            throw new NotImplementedException();
        }

        public double GetPizzaCost()
        {
            throw new NotImplementedException();
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