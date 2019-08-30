using System;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;
using System.Linq;

namespace PizzaBox.Domain.Models
{
    public class Inventory 
    {
        public int InventoryId { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        /**
        An Inventory contains a list of ingredients--sellables--available to a store
        + Must be able to add/remove sellables from inventory
        + Must be able to view all sellables in inventory
        */
        private Dictionary<ISellable, int> _items = new Dictionary<ISellable, int>();
        public Dictionary<ISellable, int> Items { get => _items; set => _items = value; }

        public Inventory() {}
    }
}