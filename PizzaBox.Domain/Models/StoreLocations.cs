using System.Collections.Generic;

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

        private StoreLocations() {}
    }
}