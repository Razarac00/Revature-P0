using System;
using Xunit;
using PizzaBox.Domain.Models;

namespace PizzaBox.Testing.UnitTests
{
    /**
    ### order
    + should be able to view its pizzas
    + should be able to compute its cost
    + should be able to limit its cost to no more than $5000
    + should be able to limit its pizza count to no more than 100
     */
    public class OrderTests
    {
        [Fact]
        public void CanViewOrder()
        {

        }

        [Fact]
        public void CanComputeCost()
        {

        }

        [Fact]
        public void CheckCostLimit()
        {
            var order1 = new Order();
            var goldjalapenos = new Topping("goldjalapenos");

        }

        [Fact]
        public void CheckPizzaCount()
        {
            
        }

        [Fact]
        public void CanCompleteAnOrder()
        {
            var order1 = new Order();
        }
    }
}