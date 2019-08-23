using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Data.Entities;

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
                Read();
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
                if (store.Location.AddressLine.ToUpper() == addressLine.ToUpper())
                {
                    return store;
                }
            }
            return null;
        }

        private static void Read()
        {
            var db = new projectzeroDBContext();
            foreach (Data.Entities.Address adb in db.Address)
            {
                var store = new Store();
                store.Location.AddressLine = adb.AddressLine;
                store.Location.City = adb.City;

                _stores.Add(store);
            }
        }

        private static void Save(Store store)
        {
            var db = new projectzeroDBContext();
            db.Address.Add(new Data.Entities.Address
            {
                AddressLine = store.Location.AddressLine,
                City = store.Location.City
            });
            db.SaveChanges();
            StoreLocations.Instance().Add(store);
        }

        private StoreLocations() {}
    }
}