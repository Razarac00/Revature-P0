using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class APizzaCreator // The Pizzamaker. The Schema.
    {
        protected APizza _product;
        public APizza Product 
        { 
            get
            {
                return _product;
            } 
        }

        public abstract APizza Make();

        protected APizzaCreator()
        {
        } 
    }
}