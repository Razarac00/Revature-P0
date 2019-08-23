using System;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class User 
    {
        private Name _name = new Name();
        public Name Name { get => _name; set => _name = value; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<Order> UserOrderHistory { get; set; }

        public Address LatestStore { get; set; }

        public Pizza CustomPizza { get; set; }

        public void PrintOrderHistory()
        {
            if (UserOrderHistory == null)
            {
                Console.WriteLine("--- No orders yet! Order some PIZZA! ---");
            }
            else
            {
                foreach (var order in UserOrderHistory)
                {
                    Console.WriteLine(order.ToString());
                }
            }
        }

    }
}