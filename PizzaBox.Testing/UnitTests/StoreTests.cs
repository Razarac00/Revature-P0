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
        var address1 = new Address("test1", "city1");
        // store.Location = address1;
        var order1 = new Order();
        var addressedOrder = new AddressedOrder(address1, order1);
        // store.StoreOrderHistory.Orders.Add(addressedOrder);

        //When
        var expected = new List<AddressedOrder> {addressedOrder};
        var actual = store.ViewOrders();

        //Then
        Assert.True(expected.Equals(actual));
        }

        [Fact]
        public void CanViewSales()
        {
        //Given
        var store = new Store();
        //When
        var actual = store.ViewSales();
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
        var store = new Store();
        //When
        var actual = store.ViewUsers();
        //Then
        }
    }
}