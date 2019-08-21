using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class User // will need a singleton to hold list of all users in the system
    {
        public Name UserName { get; set; }

        public List<Order> UserOrderHistory { get; set; }

        public ILocation LatestStore { get; set; }

        public Pizza CustomPizza { get; set; }

    }
}