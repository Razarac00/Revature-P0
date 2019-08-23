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
            var user = new User();
            var actual = user.UserOrderHistory;
        }

        [Fact]
        public void OneOrderLocationADay()
        {

        }

        [Fact]
        public void OneOrderWithinTwoHours()
        {

        }

        [Fact]
        public void OnlyAccountsCanOrder()
        {
            
        }
    }

}