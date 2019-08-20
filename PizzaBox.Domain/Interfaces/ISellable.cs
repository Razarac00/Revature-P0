namespace PizzaBox.Domain.Interfaces
{
    public interface ISellable
    {
        decimal Price { get; set; }

        string Name { get; set; }

        string ToString();
    }
}