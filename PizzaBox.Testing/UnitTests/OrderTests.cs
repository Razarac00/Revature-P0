using System;
using Xunit;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Recipes;
using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;

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
            var order1 = new Order();
            var goldjalapenos = new Topping("goldjalapenos", 250m);
            var jalaList = $"Order ";
            for (int i = 0; i <= 3; i++)
            {
                order1.AddToOrderItems(goldjalapenos);
                jalaList = jalaList + " " + goldjalapenos.ToString();
            }

            var expected = jalaList;
            var actual = order1.ToString();

            Assert.True(expected == actual);
        }

        [Fact]
        public void CanComputeCost()
        {
            var order1 = new Order();
            var goldjalapenos = new Topping("goldjalapenos");
            order1.AddToOrderItems(goldjalapenos);

            var actual = order1.ComputeTotalPrice();
            var expected = goldjalapenos.Price;

            Assert.True(actual == expected);        
        }

        [Fact]
        public void CheckCostLimit()
        {
            var order1 = new Order();
            var goldjalapenos = new Topping("goldjalapenos", 2500m);
            for (int i = 0; i <= 3; i++)
            {
                order1.AddToOrderItems(goldjalapenos);
            }

            var actual = order1.ComputeTotalPrice();
            var expected = 2 * goldjalapenos.Price;

            Assert.True(actual == expected);
        }

        [Fact]
        public void CheckPizzaCount()
        {
            var order1 = new Order();
            var goldjalapenos = new Topping("goldjalapenos");
            Standard std = new Standard();
            Pizza pizza = std.Make() as Pizza;

            order1.AddToOrderItems(goldjalapenos);
            order1.AddToOrderItems(pizza);

            var actual = order1.GetTotalPizzas();
            var expected = 1;

            Assert.True(actual == expected);            
        }

        [Fact]
        public void CheckPizzaCountLimit()
        {
            var order1 = new Order();
            var goldjalapenos = new Topping("goldjalapenos");
            Standard std = new Standard();
            Pizza pizza = std.Make() as Pizza;
            
            order1.AddToOrderItems(goldjalapenos);
            for (int i = 0; i <= 150 ; i++)
            {
               order1.AddToOrderItems(pizza);   
            }

            var actual = order1.GetTotalPizzas();
            var expected = 100;

            Assert.True(actual == expected);            
        }

        [Fact]
        public void CanCompleteAnOrder()
        {
            var order1 = new Order();
            var goldjalapenos = new Topping("goldjalapenos");
            order1.AddToOrderItems(goldjalapenos);
        }
    }
}