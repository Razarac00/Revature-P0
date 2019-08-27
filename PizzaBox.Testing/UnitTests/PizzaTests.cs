using System;
using Xunit;
using PizzaBox.Domain.Models;
using System.Collections.Generic;

namespace PizzaBox.Testing.UnitTests
{
    /**
    ### pizza
    + should be able to have a size
    + should be able to compute its cost
    + should be able to have at least 2 default toppings
    + should be able to have a crust
    + should be able to limit its toppings to no more than 5
     */
    public class PizzaTests
    {
        [Fact]
        public void PizzaHasSize()
        {
            var pizza = new Pizza();

            var expected = new Size("medium");
            var actual = pizza.Size;

            Assert.True(expected.Name == actual.Name);
        }

        [Fact]
        public void PizzaHasCost()
        {
        //Given
        var pizza = new Pizza();
        
        //When
        var expected = 2.50m;
        var actual = pizza.Price;
        
        //Then
        Assert.True(expected == actual);
        }

        [Fact]
        public void PizzaHasMinTwoToppings()
        {
        //Given
        var pizza = new Pizza();
        //When
        List<Topping> expected = null;
        var actual = pizza.Toppings;

        //Then
        Assert.False(expected == actual);
        }

        [Fact]
        public void PizzaHasMaxFiveToppingsException()
        {
        //Given
        var pizza = new Pizza();
        //When
        List<Topping> toppingList = new List<Topping> 
        {
            new Topping("Jalapenos"),
            new Topping("Green Peppers"),
            new Topping("Red Peppers"),
            new Topping("Mushrooms"),
            new Topping("Cheese")
        };

        pizza.AddTopping(toppingList);
        pizza.AddTopping(new Topping("Pineapple"));
        var actual = pizza.Toppings.Count;
        var expected = 5;

        //Then
        Assert.NotNull(actual);
        Assert.True(actual == expected);
        }

        [Fact]
        public void PizzaHasCrust()
        {
        //Given
        var pizza = new Pizza();
        var CrustName = "traditional";
        //When
        var expected = new Crust(CrustName);
        var actual = pizza.Crust;

        //Then
        Assert.True(expected.Name == actual.Name);
        }
    }
}