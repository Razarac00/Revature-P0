using System;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class AItem
    {
        private string _defaultName = "Item Name";
        private decimal _defaultPrice = 1.00m;

        public string Name { get; set; }
        public decimal Price { get; set; }

        private decimal SetupPrice( decimal value)
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
    }
}