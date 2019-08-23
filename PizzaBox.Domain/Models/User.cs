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

        public ILocation LatestStore { get; set; }

        public Pizza CustomPizza { get; set; }

    }
}