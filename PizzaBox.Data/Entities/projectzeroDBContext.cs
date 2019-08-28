using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaBox.Data.Entities
{
    public partial class projectzeroDBContext : DbContext
    {
        public projectzeroDBContext()
        {
        }

        public projectzeroDBContext(DbContextOptions<projectzeroDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Crust> Crust { get; set; }
        public virtual DbSet<CrustInventory> CrustInventory { get; set; }
        public virtual DbSet<OrderPizzas> OrderPizzas { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaToppings> PizzaToppings { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Topping> Topping { get; set; }
        public virtual DbSet<ToppingInventory> ToppingInventory { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserOrders> UserOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:project-zero-john.database.windows.net,1433;Initial Catalog=projectzeroDB;Persist Security Info=False;User ID=sqladmin;Password=#4EMDnope;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "Store");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressLine)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Crust>(entity =>
            {
                entity.ToTable("Crust", "Pizza");

                entity.Property(e => e.CrustId).HasColumnName("CrustID");

                entity.Property(e => e.CrustName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Price).HasColumnType("decimal(2, 2)");
            });

            modelBuilder.Entity<CrustInventory>(entity =>
            {
                entity.HasKey(e => new { e.AddressId, e.CrustId })
                    .HasName("PK_ACID");

                entity.ToTable("CrustInventory", "Store");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.CrustId).HasColumnName("CrustID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.CrustInventory)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CAddressID");

                entity.HasOne(d => d.Crust)
                    .WithMany(p => p.CrustInventory)
                    .HasForeignKey(d => d.CrustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CCrustID");
            });

            modelBuilder.Entity<OrderPizzas>(entity =>
            {
                entity.HasKey(e => new { e.UserOrderId, e.PizzaId })
                    .HasName("PK_UPID");

                entity.ToTable("OrderPizzas", "User");

                entity.Property(e => e.UserOrderId).HasColumnName("UserOrderID");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.OrderPizzas)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPizzaID");

                entity.HasOne(d => d.UserOrder)
                    .WithMany(p => p.OrderPizzas)
                    .HasForeignKey(d => d.UserOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserOrderID");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "Pizza");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.CrustId).HasColumnName("CrustID");

                entity.Property(e => e.PizzaName).HasMaxLength(25);

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.HasOne(d => d.Crust)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.CrustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CrustId");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Pizza)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SizeId");
            });

            modelBuilder.Entity<PizzaToppings>(entity =>
            {
                entity.HasKey(e => e.PizzaToppingId)
                    .HasName("PK_PizzaToppingID");

                entity.ToTable("PizzaToppings", "Pizza");

                entity.Property(e => e.PizzaToppingId).HasColumnName("PizzaToppingID");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.ToppingId).HasColumnName("ToppingID");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaToppings)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaID");

                entity.HasOne(d => d.Topping)
                    .WithMany(p => p.PizzaToppings)
                    .HasForeignKey(d => d.ToppingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToppingID");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size", "Pizza");

                entity.Property(e => e.SizeId).HasColumnName("SizeID");

                entity.Property(e => e.Price).HasColumnType("decimal(2, 2)");

                entity.Property(e => e.Size1)
                    .IsRequired()
                    .HasColumnName("Size")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.ToTable("Topping", "Pizza");

                entity.Property(e => e.ToppingId).HasColumnName("ToppingID");

                entity.Property(e => e.Price).HasColumnType("decimal(2, 2)");

                entity.Property(e => e.ToppingName)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<ToppingInventory>(entity =>
            {
                entity.HasKey(e => new { e.AddressId, e.ToppingId })
                    .HasName("PK_ATID");

                entity.ToTable("ToppingInventory", "Store");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.ToppingId).HasColumnName("ToppingID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.ToppingInventory)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TAddressID");

                entity.HasOne(d => d.Topping)
                    .WithMany(p => p.ToppingInventory)
                    .HasForeignKey(d => d.ToppingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TToppingID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "User");

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__User__C9F2845649240E13")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.LastName).HasMaxLength(25);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<UserOrders>(entity =>
            {
                entity.HasKey(e => e.UserOrderId)
                    .HasName("PK_UserOrderID");

                entity.ToTable("UserOrders", "User");

                entity.Property(e => e.UserOrderId).HasColumnName("UserOrderID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.OrderDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.UserOrders)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AddressID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOrders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserOrdersUserID");
            });
        }
    }
}
