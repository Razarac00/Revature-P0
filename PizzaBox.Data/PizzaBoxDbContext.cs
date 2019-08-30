using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Data
{
    public class PizzaBoxDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=tcp:project-zero-john.database.windows.net,1433;Initial Catalog=ProjectZeroTwoDB;Persist Security Info=False;User ID=sqladmin;Password=Mafia123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }    
}