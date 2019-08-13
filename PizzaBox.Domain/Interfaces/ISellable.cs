namespace PizzaBox.Domain.Interfaces
{
    public interface ISellable
    {
        double Price { get; set; }

        string Name { get; set; }
    }
}