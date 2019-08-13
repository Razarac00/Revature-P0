using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Topping : ISellable
    {
        public double Price { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        private string v;

        public Topping(string v)
        {
            this.v = v;
        }

    }
}