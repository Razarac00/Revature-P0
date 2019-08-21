using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Recipes
{
    public class NewYork : APizza // The Pizzamaker Machine.
    {
        /**
        new List<Topping> 
            {
                new Topping("Basil"),
                new Topping("Marinara")
            });
        */
        public override List<AItem> Make(Size s, List<Topping> t)
        {
            var product = new List<AItem>(); // lazy instantiation
            product.Add(new Crust("NYStyle"));
            product.Add(s);
            product.AddRange(t);
            return product;
            // return pizzatype cause pizza product is what we make;

        }



    }
}