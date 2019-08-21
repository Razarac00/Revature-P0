using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class InventoryList // Inventories-- a single list of inventories kept by all stores. Singleton makes sense with that
    {
        /**
        An Inventory contains a list of ingredients--sellables--available to a store
        + Must be able to add/remove sellables from inventory
        + Must be able to view all sellables in inventory
        */
        private static List<Inventory> _library;

        public static List<Inventory> Instance()
        {
            if (_library == null)
            {
                _library = new List<Inventory>();
            }
            return _library;
        }

        private InventoryList() {}
    }
}