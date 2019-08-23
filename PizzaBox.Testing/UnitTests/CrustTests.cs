using System;
using Xunit;
using PizzaBox.Domain.Models;

namespace PizzaBox.Testing.UnitTests
{
    public class CrustTests
    {
        [Fact]
        public void CrustHasDefaultPrice()
        {
            var crust = new Crust("Traditional");
            var actual = crust.Price;
            var expected = 1.50m;

            Assert.True(actual == expected);

        }
    }
}