using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Data.Entities;

namespace PizzaBox.Domain.Models
{
    public class OrderHistory 
    {
        private List<AddressedOrder> _orders = new List<AddressedOrder>();

        public List<AddressedOrder> Orders { get => _orders; set => _orders = value; }

        private void Read()
        {
            var db = new projectzeroDBContext();
            foreach (Data.Entities.UserOrders uOrder in db.UserOrders)
            {
                var aOrder = new AddressedOrder();
                aOrder.Address.AddressLine = uOrder.Address.AddressLine;
                aOrder.Address.City = uOrder.Address.City;
                aOrder.Date = uOrder.OrderDate;
                var order = from OrderPizzas op in db.UserOrders.Include("OrderPizzas").ToList()
                            where op.UserOrderId == uOrder.UserOrderId
                            select op;
                var ordList = new Order();
                // ordList.AddToOrderItems(order.ToList());
                aOrder.Order = ordList;

                Orders.Add(aOrder);
            }
        }

        public OrderHistory() {}
    }
}