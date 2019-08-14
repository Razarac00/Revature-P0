using System;
using Xunit;
using PizzaBox.Domain.Models;

namespace PizzaBox.Testing.UnitTests
{

    public class UserTests
    {
        /**
        ### user
        + should be able to view its order history
        + should be able to only order from 1 location/day
        + should be able to only order 1 time within a 2 hour period
        + should be able to only order if an account exists
        */
        [Fact]
        public void CanViewOrderHistory() 
        {

        }

        [Fact]
        public void OneOrderLocationADayException()
        {

        }

        [Fact]
        public void OneOrderWithinTwoHoursException()
        {

        }

        [Fact]
        public void OnlyAccountsCanOrderException()
        {
            
        }
    }

}