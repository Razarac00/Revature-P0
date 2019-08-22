using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class OrderHistory 
    {
        private List<Order> _orders;

        public List<Order> Instance()
        {
            if (_orders == null)
            {
                _orders = new List<Order>();
            }
            return _orders;
        }

        public OrderHistory() {}
    }
}