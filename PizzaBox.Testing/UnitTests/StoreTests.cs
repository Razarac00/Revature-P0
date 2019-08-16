using System;
using Xunit;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Testing.UnitTests
{
    public class StoreTests 
    {
        /** ### Location -> Store
        + should be able to view its orders
        + should be able to view its sales
        + should be able to view its inventory
        + should be able to view its users
        */
        [Fact]
        public void CanViewOrders()
        {
        //Given
        
        //When
        
        //Then
        }

        [Fact]
        public void CanViewSales()
        {
        //Given
        
        //When
        
        //Then
        }

        [Fact]
        public void CanViewInventory()
        {
        //Given
        var store = new Store();
        //When
        Inventory actual = store.Inventory;
        
        //Then
        Assert.IsType<Inventory>(actual);
        }

        [Fact]
        public void CanViewUsers()
        {
        //Given
        
        //When
        
        //Then
        }
    }
}