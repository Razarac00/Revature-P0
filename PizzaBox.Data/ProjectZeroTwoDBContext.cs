using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Data
{
    public class ProjectZeroTwoDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<AddressedOrder> AddressedOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Size> Sizes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=tcp:project-zero-john.database.windows.net,1433;Initial Catalog=ProjectZeroTwoDB;Persist Security Info=False;User ID=sqladmin;Password=Mafia123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(u => u.UserId);
            builder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
            builder.Entity<User>().HasOne(u => u.Name);
            // builder.Entity<User>().HasOne(u => u.UserOrderHistory);
            // builder.Entity<User>().HasMany(u => u.UserOrderHistory.Orders).WithOne(o => o.OrderUser).HasForeignKey(u => u.AddressedOrderId);
            
        }
    }    
}