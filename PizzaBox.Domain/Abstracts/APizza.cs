using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class APizza // The Pizzamaker. The Schema.
    {
        protected List<AItem> _items;
        public List<AItem> Items 
        { 
            get
            {
                return Items;
            } 
        }

        public abstract List<AItem> Make(Size s, List<Topping> t);

        protected APizza()
        {
        } 
    }
}