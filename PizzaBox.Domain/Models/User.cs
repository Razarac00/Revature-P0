using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class User 
    {
        public Name Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public List<Order> UserOrderHistory { get; set; }

        public ILocation LatestStore { get; set; }

        public Pizza CustomPizza { get; set; }

    }
}