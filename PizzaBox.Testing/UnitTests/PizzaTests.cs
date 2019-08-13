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

            var expected = 12;
            var actual = pizza.GetPizzaSize();

            Assert.True(expected == actual);
        }

        [Fact]
        public void PizzaHasCost()
        {
        //Given
        var pizza = new Pizza();
        
        //When
        var expected = 9.99;
        var actual = pizza.GetPizzaCost();
        
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
        var actual = pizza.GetPizzaToppings();

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
            new Topping("Red Peppers")
        };

        pizza.AddTopping(toppingList);
        var actual = Record.Exception(pizza.AddTopping(new Topping("Pineapple")));

        //Then
        Assert.NotNull(actual);
        Assert.IsType<ArgumentOutOfRangeException>(actual);
        }

        [Fact]
        public void PizzaHasCrust()
        {
        //Given
        var pizza = new Pizza();
        //When
        var expected = new Crust();
        var actual = pizza.getPizzaCrust();

        //Then
        Assert.True(expected == actual);
        }
    }
}