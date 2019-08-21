using System;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;
using System.Linq;

namespace PizzaBox.Domain.Models
{
    public class Inventory // Inventories-- a single list of inventories kept by all stores. Singleton makes sense with that
    {
        /**
        An Inventory contains a list of ingredients--sellables--available to a store
        + Must be able to add/remove sellables from inventory
        + Must be able to view all sellables in inventory
        */
        private Dictionary<ISellable, int> _items;
        public Dictionary<ISellable, int> Items { get => _items; set => _items = value; }

        public Inventory() {}
    }
}