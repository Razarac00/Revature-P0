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
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaToppings> PizzaToppings { get; set; }
        public virtual DbSet<RecentStores> RecentStores { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Topping> Topping { get; set; }
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

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order", "User");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderDate).HasColumnType("datetime2(0)");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza", "Pizza");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.CrustId).HasColumnName("CrustID");

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

            modelBuilder.Entity<RecentStores>(entity =>
            {
                entity.HasKey(e => e.RecentStoreId)
                    .HasName("PK_RecentStoreID");

                entity.ToTable("RecentStores", "User");

                entity.Property(e => e.RecentStoreId).HasColumnName("RecentStoreID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.RecentStores)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StoreID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RecentStores)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserID");
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

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "Store");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");
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

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.UserOrders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOrders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserOrdersUserID");
            });
        }
    }
}
