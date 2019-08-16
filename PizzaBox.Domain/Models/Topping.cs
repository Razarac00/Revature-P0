using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Topping : ISellable
    {
        private double _defaultPrice = 0.50;
        public double Price 
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

        public Topping(string name, double price)
        {
            Name = name;
            Price = price;
        }

    }
}