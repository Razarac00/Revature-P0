using System;
using System.Collections.Generic;
using PizzaBox.Data.Entities;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class User 
    {
        private Name _name = new Name();
        private AddressedOrder _latestOrder = new AddressedOrder();
        public Name Name { get => _name; set => _name = value; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<AddressedOrder> UserOrderHistory { get; set; }
        public AddressedOrder LatestOrder { get => _latestOrder; set => _latestOrder = value; }
        private AddressedOrder CurrentOrder { get; set; }
        public Pizza CustomPizza { get; set; }

        public AddressedOrder StartOrder(Address address)
        {
            var order = new Order();
            CurrentOrder = new AddressedOrder(address, order);
            return CurrentOrder;
        }

        public AddressedOrder FinishOrder()
        {
            CurrentOrder.Date = DateTime.Now;

            if (LatestOrder is null ||  (CurrentOrder.Date.Hour - LatestOrder.Date.Hour) >= 2)
            {
                Save(CurrentOrder);
                return CurrentOrder;
            }

            return null;
        }

        private void Save(AddressedOrder currentOrder)
        {
            var db = new projectzeroDBContext();
            db.Order.Add(new Data.Entities.Order
            {
                OrderDate = currentOrder.Date,
                Active = true
            });
            LatestOrder = CurrentOrder;
            UserOrderHistory.Add(CurrentOrder);
            //db.SaveChanges();
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