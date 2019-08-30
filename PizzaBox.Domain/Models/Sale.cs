using System;

namespace PizzaBox.Domain.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int OrderId { get; set; }
        private Order _order = new Order();
        public Order Order { get => _order; set => _order = value; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }

        public Sale()
        {
        }

        public Sale(Order order, DateTime date, decimal price)
        {
            Order = order;
            Date = date;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Order} at {Date} for price: {Price}";
        }
    }
}