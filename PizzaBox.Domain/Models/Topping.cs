using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Topping : ISellable
    {
        private decimal _defaultPrice = 0.50m;
        public decimal Price 
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

        public string Name {get; set;}

        public Topping(string name)
        {
            Name = name;
        }

        public Topping(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

    }
}