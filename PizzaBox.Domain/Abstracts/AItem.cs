using System;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class AItem : ISellable
    {
        private string _defaultName = "Item Name";
        private decimal _defaultPrice = 1.00m;

        public decimal Price 
        { 
            get => _defaultPrice; 
            set => _defaultPrice = SetupPrice(value); 
        }
        public string Name 
        { 
            get => _defaultName; 
            set => _defaultName = SetupName(value);
        }

        private decimal SetupPrice(decimal value)
        {
         decimal result = _defaultPrice;
            if (value > 0)
            {
                result = value;
            }
            return result;
        }

        private string SetupName(string value)
        {
            string result = _defaultName;
            if (!String.IsNullOrEmpty(value))
            {
                result = value;
            }
            return result;
            
        }

        public AItem(string name)
        {
            Name = name;
        }

        public AItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name}: ${Price}";
        }
    }
}