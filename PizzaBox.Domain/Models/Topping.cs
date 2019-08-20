using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Topping : AItem, ISellable
    {
        private decimal _defaultPrice = 0.50m;
        public new decimal Price 
        { 
            get 
            {
                return this._defaultPrice;
            } 
            set
            {
                this._defaultPrice = value; 
            }
        }

        public Topping(string name) : base(name)
        {
            Name = name;
        }

        public Topping(string name, decimal price) : base(name)
        {
            Name = name;
            Price = price;
        }

    }
}