using System;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;
using System.Linq;

namespace PizzaBox.Domain.Models
{
    public class Inventory
    {
        /**
        An Inventory contains a list of ingredients--sellables--available to a store
        + Must be able to add/remove sellables from inventory
        + Must be able to view all sellables in inventory
        */
        private static Dictionary<ISellable, int> _items;

        public static Dictionary<ISellable, int> Instance()
        {
            if (_items == null)
            {
                _items = new Dictionary<ISellable, int>();
            }
            return _items;
        }

        private Inventory() {}
    }
}