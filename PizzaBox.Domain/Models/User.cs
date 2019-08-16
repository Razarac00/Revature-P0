using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class User
    {
        public Name UserName { get; set; }

        public List<Order> UserOrders { get; set; }

        public ILocation LatestStore { get; set; }

        public Pizza CustomPizza { get; set; }

    }
}