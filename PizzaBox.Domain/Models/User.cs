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
        public List<AddressedOrder> UserOrderHistory { get; set; }
        public Address LatestStore { get; set; }
        private AddressedOrder CurrentOrder { get; set; }
        public Pizza CustomPizza { get; set; }

        public AddressedOrder StartOrder(Address address)
        {
            var order = new Order();
            CurrentOrder = new AddressedOrder();
            CurrentOrder.Address = address;
            CurrentOrder.Order = order;
            return CurrentOrder;
        }

        public AddressedOrder FinishOrder()
        {
            LatestStore = CurrentOrder.Address;

            return CurrentOrder;
        }

        public void PrintOrderHistory()
        {
            if (UserOrderHistory == null)
            {
                Console.WriteLine("--- No orders yet! Order some PIZZA! ---");
            }
            else
            {
                foreach (var addressedOrder in UserOrderHistory)
                {
                    Console.WriteLine(addressedOrder.ToString());
                }
            }
        }

    }
}