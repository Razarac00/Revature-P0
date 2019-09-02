using System;
using Xunit;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Recipes;

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
        store.Location = address1;
        var order1 = new Order();
        var addressedOrder = new AddressedOrder(address1, order1);
        store.StoreOrderHistory.Orders.Add(addressedOrder);

        //When
        var expected = new List<Order> {order1};
        var actual = store.ViewOrders();
        
        //Then
        Assert.True(expected.All(actual.Contains) && actual.Count == expected.Count);
        }

        [Fact]
        public void CanViewSales()
        {
        //Given
        var store = new Store();
        var address1 = new Address("test1", "city1");
        store.Location = address1;
        var order1 = new Order();
        var pizza1 = new Standard().Make() as Pizza;
        var pizza2 = new NewYork().Make() as Pizza;
        var pizzaList = new List<ISellable>{pizza1,pizza2};
        order1.AddToOrderItems(pizzaList);

        var addressedOrder = new AddressedOrder(address1, order1);
        store.StoreOrderHistory.Orders.Add(addressedOrder);
        //When
        var expectedTotal = pizza1.Price + pizza2.Price;
        var actual = store.ViewSales();
        var expected = new List<Sale> {new Sale(order1, addressedOrder.Date, expectedTotal)};
        //Then
        Assert.True(actual.Count == expected.Count && expectedTotal == actual[0].Price && expected[0].Date == actual[0].Date);
        }

        [Fact]
        public void InventoryIsList()
        {
        //Given
        var store = new Store();
        //When
        List<InventoryItem> actual = store.Inventory.Items;
        
        //Then
        Assert.IsType<List<InventoryItem>>(actual);
        }

        [Fact]
        public void CanViewUsers()
        {
        //Given
        var store = new Store();
        var address1 = new Address("test1", "city1");
        store.Location = address1;
        var order1 = new Order();
        var addressedOrder = new AddressedOrder(address1, order1);
        var orderUser = new User();
        orderUser.Name.First = "test";
        orderUser.Name.Last = "user";
        addressedOrder.OrderUser = orderUser;
        store.StoreOrderHistory.Orders.Add(addressedOrder);

        //When
        var actual = store.ViewUsers();
        var expected = new List<User> {orderUser};
        //Then
        Assert.True(expected.All(actual.Contains) && actual.Count == expected.Count);
        }
    }
}