using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Topping : AItem
    {
        private decimal _defaultPrice = 0.50m;
        public override decimal Price 
        { 
            get 
            {
                return _defaultPrice;
            } 
            set
            {
                _defaultPrice = value; 
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