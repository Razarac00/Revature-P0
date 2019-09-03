using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
// using PizzaBox.Data.Entities;

namespace PizzaBox.Domain.Models
{
    public class OrderHistory 
    {
        public int OrderHistoryId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }

        private List<AddressedOrder> _orders = new List<AddressedOrder>();

        public List<AddressedOrder> Orders { get => _orders; set => _orders = value; }

        private OrderHistory() {}
    }
}