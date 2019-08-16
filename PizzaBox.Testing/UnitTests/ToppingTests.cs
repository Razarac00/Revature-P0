using System;
using Xunit;
using PizzaBox.Domain.Models;

namespace PizzaBox.Testing.UnitTests
{
    public class ToppingTests
    {
        [Fact]
        public void ToppingHasDefaultPrice()
        {
        //Given
        var habanero = new Topping("habenero");
        //When
        var expected = 0.50m;
        var actual = habanero.Price;
        
        //Then
        Assert.True(expected == actual);
        }

        [Fact]
        public void ToppingHasSetPrice()
        {
        //Given
        var expected = 1.75m;
        var habanero = new Topping("habanero", expected);
        //When
        var actual = habanero.Price;
        
        //Then
        Assert.True(expected == actual);
        }

        [Fact]
        public void ToppingHasName()
        {
        //Given
        var expected = "habanero";
        var habanero = new Topping(expected);
        //When
        var actual = habanero.Name;
        
        //Then
        Assert.True(expected == actual);
        }


    }
}