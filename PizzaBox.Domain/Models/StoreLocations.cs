using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Domain.Models
{
    public class StoreLocations
    {
        private static List<Store> _stores;

        public static List<Store> Instance()
        {
            if (_stores == null)
            {
                _stores = new List<Store>();
            }
            return _stores;
        }

        public static void PrintStores()
        {
            foreach (Store s in Instance())
            {
                Console.WriteLine(s.ToString());
            }
        }

        public static Store GetStoreByAddress(string addressLine)
        {
            foreach (var store in Instance())
            {
                if (store.Address.AddressLine.ToUpper() == addressLine.ToUpper())
                {
                    return store;
                }
            }
            return null;
        }
        private StoreLocations() {}
    }
}