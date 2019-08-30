using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class InventoryItem
    {
        public int InventoryItemId { get; set; }
        public AItem Item { get; set; }
        public int Amount { get; set; }
    }
}