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
        var expected = 0.50;
        var actual = habanero.Price;
        
        //Then
        Assert.True(expected == actual);
        }
    }
}