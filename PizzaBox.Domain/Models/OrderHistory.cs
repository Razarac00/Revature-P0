using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class OrderHistory
    {
        private static List<Order> _orders;

        public static List<Order> Instance()
        {
            if (_orders == null)
            {
                _orders = new List<Order>();
            }
            return _orders;
        }

        private OrderHistory() {}
    }
}