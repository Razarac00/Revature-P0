namespace PizzaBox.Domain.Models
{
    public class Address
    {
        public string AddressLine { get; set; }
        public string City { get; set; }

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