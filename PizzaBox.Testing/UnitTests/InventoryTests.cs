using System;
using Xunit;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;
using System.Linq;

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
        //When
        var expected = true;
        storage.AddItem(crust);
        var actual = storage.HasItem(crust.Name);
        //Then
        Assert.True(expected == actual);
        }

        [Fact]
        public void RemoveFromInventoryTest()
        {
        //Given
        var storage = new Inventory();
        var crust = new Crust("traditional");
        //When
        var expected = true;
        storage.RemoveItem(crust);
        var actual = storage.HasItem(crust.Name);
        //Then
        Assert.True(expected != actual);
        }

        [Fact]
        public void ViewInventoryTest()
        {
        //Given
        var storage = new Inventory();
        //When
        var crust = new Crust("traditional");
        var jalapenos = new Topping("Jalapenos");
        
        storage.AddItem(crust);
        storage.AddItem(jalapenos);

        var expected = new List<ISellable> {crust, jalapenos};
        var actual = storage.ViewItems();

        var firstNotSecond = expected.Except(actual).ToList();
        var secondNotFirst = actual.Except(expected).ToList();
        //Then
        Assert.True(!firstNotSecond.Any() && !secondNotFirst.Any());

        }
    }


}