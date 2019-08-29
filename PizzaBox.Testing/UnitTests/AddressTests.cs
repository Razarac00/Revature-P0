using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.UnitTests
{
    public class AddressTests
    {
        [Fact]
        public void CanConstructEmptyAddress()
        {
        //Given
        var address1 = new Address();
        //When
        
        //Then
        Assert.NotNull(address1);
        }

        [Fact]
        public void CanConstructFilledAddress()
        {
        //Given
        var address1 = new Address("address1", "city1");
        //When
        var expected = "address1 city1";
        var actual = address1.ToString();
        //Then
        Assert.NotNull(address1);
        Assert.True(expected == actual);
        }

        [Fact]
        public void CanSetupEmptyAddress()
        {
        //Given
        var address1 = new Address();
        address1.AddressLine = "address1";
        address1.City = "city1";
        //When
        var expected = "address1 city1";
        var actual = address1.ToString();
        
        //Then
        Assert.True(expected == actual);
        }
    }
}