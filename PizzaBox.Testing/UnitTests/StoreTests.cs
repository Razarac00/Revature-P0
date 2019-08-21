using System;
using Xunit;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Interfaces;
using System.Collections.Generic;

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
        var store = new Store();
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
        public void InventoryIsDictionary()
        {
        //Given
        var store = new Store();
        //When
        Dictionary<ISellable, int> actual = store.Inventory;
        
        //Then
        Assert.IsType<Dictionary<ISellable, int>>(actual);
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