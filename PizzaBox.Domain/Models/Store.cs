using System;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Store
    {
        private int _defaultRecentUserTimeLimit = 24;
        private Address _location = new Address();
        private OrderHistory _storeOrderHistory = new OrderHistory();
        private Dictionary<ISellable, int> _inventory = new Inventory().Items;
        public Address Location { get => _location; set => _location = value; }
        public Dictionary<ISellable, int> Inventory { get => _inventory; set => _inventory = value; }
        public OrderHistory StoreOrderHistory { get => _storeOrderHistory; set => _storeOrderHistory = value; }

        public List<User> ViewUsers()
        {
            DateTime present = DateTime.Now;
            List<User> recentUsers = new List<User>();

            foreach (AddressedOrder aOrder in StoreOrderHistory.Orders)
            {
                if (!CheckTimeLimitReached(aOrder, present))
                {
                    recentUsers.Add(aOrder.OrderUser);
                }
            }
            return recentUsers;
        }

        public List<Order> ViewOrders()
        {
            var result = new List<Order>();
            foreach (AddressedOrder aOrder in StoreOrderHistory.Orders)
            {
                result.Add(aOrder.Order);
            }
            return result;
        }

        public List<Sale> ViewSales()
        {
            var result = new List<Sale>();
            foreach (AddressedOrder aOrder in StoreOrderHistory.Orders)
            {
                var sale = new Sale(aOrder.Order, aOrder.Date, aOrder.FinalPrice);
                result.Add(sale);
            }
            return result;
        }

        private bool CheckTimeLimitReached(AddressedOrder aOrder, DateTime dTime)
        {
            var tempTime = aOrder.Date.AddHours(_defaultRecentUserTimeLimit);

            var result = tempTime.CompareTo(dTime) >= 0;
            return result;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} Address: {Location.AddressLine} City: {Location.City}";
        }


    }
}