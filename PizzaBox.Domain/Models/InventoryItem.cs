using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class InventoryItem
    {
        public int InventoryItemId { get; set; }
        public AItem Item { get; set; }
        public int Amount { get; set; }
        public List<Inventory> Inventories { get; set; }

        public InventoryItem()
        {
        }

        public InventoryItem(AItem item, int amount)
        {
            Item = item;
            Amount = amount;
        }
    }
}