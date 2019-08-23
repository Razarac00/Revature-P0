using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Order
    {
        // list of items
        // total price in decimal
        // price <= 5000$ and pizza count < 100
        private decimal _defaultPriceLimit = 5000m;
        private int _defaultPizzaCountLimit = 100;
        private List<ISellable> _orderItems = new List<ISellable>();
        public List<ISellable> OrderItems { get => _orderItems; set => _orderItems = value; }

        private bool PriceLimitReached(List<ISellable> cart)
        {
            return ComputeTotalPrice(cart) > _defaultPriceLimit; 
        }

        private bool PizzaLimitReached(List<ISellable> cart)
        {
            return CountTotalPizzas(cart) > _defaultPizzaCountLimit;
        }

        private decimal ComputeTotalPrice(List<ISellable> cart)
        {
            decimal total = 0m;
            foreach (var item in cart)
            {
                total += item.Price;
            }
            return total;
        }

        private int CountTotalPizzas(List<ISellable> cart)
        {
            int total = 0;
            foreach (var item in cart)
            {
                if (item is Pizza)
                {
                    total += 1;
                }
            }
            return total;
        }
    }
}