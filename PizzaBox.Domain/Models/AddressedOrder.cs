namespace PizzaBox.Domain.Models
{
    public class AddressedOrder
    {
        public Address Address { get; set; }
        public Order Order { get; set; }

        public override string ToString()
        {
            return $"ADDRESS: {Address.ToString()}\nORDER:\t{Order.ToString()}";
        }
    }
}