using System;
using Xunit;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;
using System.Linq;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Testing.UnitTests
{       

    public class InventoryTests 
    {
        /**
        An Inventory contains a list of ingredients--sellables--available to a store
        + Must be able to add/remove sellables from inventory
        + Must be able to view all sellables in inventory
        */
        [Fact]
        public void AddToInventoryTest()
        {
        //Given
        var storage = new Inventory();
        var crust = new Crust("traditional");
        var crustItem = new InventoryItem(crust, 100);
        //When
        var expected = true;
        storage.Items.Add(crustItem);
        var actual = storage.Items.Contains(crustItem);
        storage.Items.Remove(crustItem);
        //Then
        Assert.True(expected == actual);
        }

        [Fact]
        public void RemoveFromInventoryTest()
        {
        //Given
        var storage = new Inventory().Items;
        var crust = new Crust("traditional");
        var crustItem = new InventoryItem(crust, 50);
        //When
        var expected = true;
        storage.Add(crustItem);
        var actual = storage.Remove(crustItem);
        //Then
        Assert.True(expected == actual);
        }

        [Fact]
        public void ViewInventoryTest()
        {
        //Given
        var storage = new Inventory().Items;
        //When
        var crust = new Crust("traditional");
        var jalapenos = new Topping("Jalapenos");
        var crustItem = new InventoryItem(crust, 50);
        var jalaItem = new InventoryItem(jalapenos, 100);
        storage.Add(crustItem);
        storage.Add(jalaItem);

        var expected = new List<InventoryItem> {crustItem, jalaItem};
        var actual = storage;

        var firstNotSecond = expected.Except(actual).ToList();
        var secondNotFirst = actual.Except(expected).ToList();

        //Then
        Assert.True(!firstNotSecond.Any() && !secondNotFirst.Any());

        }
    }


}