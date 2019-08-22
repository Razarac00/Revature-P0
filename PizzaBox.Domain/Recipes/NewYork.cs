using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Recipes
{
    public class NewYork : APizzaCreator // The Pizzamaker Machine.
    {

        public override APizza Make()
        {
            var pizza = new Pizza();
            var toppings = new List<Topping>
            {
                new Topping("Basil"),
                new Topping("Marinara")
            };
            var crust = new Crust("NYStyle");
            pizza.AddTopping(toppings);
            return pizza;

        }



    }
}