using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Recipes
{
    public class Standard : APizzaCreator // The Pizzamaker Machine.
    {

        public override APizza Make()
        {
            var pizza = new Pizza();
            var toppings = new List<Topping>
            {
                new Topping("Cheese"),
                new Topping("Tomato Sauce")
            };
            var crust = new Crust("traditional");
            var size = new Size("medium");
            pizza.AddTopping(toppings);
            pizza.Crust = crust;
            pizza.Size = size;
            return pizza;

        }



    }
}