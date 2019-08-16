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
        public void AddItem(ISellable item)
        {
            throw new NotImplementedException();
        }

        public bool HasItem(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(ISellable item)
        {
            throw new NotImplementedException();
        }

        public List<ISellable> ViewItems()
        {
            throw new NotImplementedException();
        }
    }
}