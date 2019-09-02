using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Domain.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int StoreId { get; set; }

        [Required(ErrorMessage="Address Required")]
        public string AddressLine { get; set; }

        [Required(ErrorMessage="City Required")]
        public string City { get; set; }
        public Store Store { get; set; }

        public Address()
        {
        }

        public Address(string address, string city)
        {
            AddressLine = address;
            City = city;
        }

        public override string ToString()
        {
            return $"{AddressLine} {City}";
        }
    }
}