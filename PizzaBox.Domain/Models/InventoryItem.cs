using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class InventoryItem
    {
        public int InventoryItemId { get; set; }
        public ISellable Item { get; set; }
        public int Amount { get; set; }
    }
}