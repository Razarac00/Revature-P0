using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Pizza : APizza
    {
        private int _defaultMaxToppings = 5;

        public void AddTopping(List<Topping> toppingList)
        {
            if (CheckToppings(toppingList))
            {
                Toppings.AddRange(toppingList);
            }
        }

        private bool CheckToppings(List<Topping> potentialToppings)
        {
            var temp = new List<Topping>();
            temp.AddRange(Toppings);
            temp.AddRange(potentialToppings);
            return temp.Count <= _defaultMaxToppings;
        }

        public void AddTopping(Topping topping)
        {
            AddTopping(new List<Topping> {topping});
        }
    }
}