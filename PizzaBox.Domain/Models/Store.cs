using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Store : ILocation
    {
        public string Street { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string City { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public Inventory Inventory { get; set; } // dictionary<item, int>
    }
}