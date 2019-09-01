using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Domain.Models
{
    public class Name
    {
        public int NameId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage="A name or initial is required")]
        public string First { get; set; }

        [Required(ErrorMessage="A name or initial is required")]
        public string Last { get; set; }
    }
}