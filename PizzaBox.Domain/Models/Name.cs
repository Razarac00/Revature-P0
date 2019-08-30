namespace PizzaBox.Domain.Models
{
    public class Name
    {
        public int NameId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }
}