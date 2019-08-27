using System;

namespace PizzaBox.Domain.Models
{
    public class AddressedOrder
    {
        private string _dateFormat = "MM/dd/yyyy HH:mm:ss";
        private DateTime _date = new DateTime();
        private Address _address = new Address();
        private Order _order = new Order();
        public Address Address { get => _address; set => _address = value; }
        public Order Order { get => _order; set => _order = value; }
        public DateTime Date { get => _date; set => _date = value; }

        public override string ToString()
        {
            return $"DATE: {Date.ToString(_dateFormat)}\nADDRESS: {Address.ToString()}\nORDER:\t{Order.ToString()}";
        }

        public AddressedOrder(Address address, Order order)
        {
            Address = address;
            Order = order;
        }

        public AddressedOrder()
        {

        }
    }
}