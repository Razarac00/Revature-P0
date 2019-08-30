using System;
using Xunit;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Interfaces;
using System.Collections.Generic;

namespace PizzaBox.Testing.UnitTests
{
    public class AddressedOrderTests
    {
        [Fact]
        public void CanCreateEmptyInstance()
        {
        //Given
        var addressedOrder = new AddressedOrder();
        //When
        
        //Then
        Assert.NotNull(addressedOrder);
        }
    }
}