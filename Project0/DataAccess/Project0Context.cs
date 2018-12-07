using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project0.DataAccess
{
    public partial class Project0Context : DbContext
    {
        public Project0Context()
        {
        }

        public Project0Context(DbContextOptions<Project0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<OrderPizzas> OrderPizzas { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizzas> Pizzas { get; set; }
        public virtual DbSet<PizzasIngredients> PizzasIngredients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:pereira1811.database.windows.net,1433;Initial Catalog = Project0; Persist Security Info=False;User ID =rodu_pereira; Password=Bospe43bo!; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "3.0.0-preview.18572.1");

            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Address_Customer");
            });

            modelBuilder.Entity<OrderPizzas>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderPizzas)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderPizza_Order");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.OrderPizzas)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderPizza_Pizza");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Address");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Customer");
            });

            modelBuilder.Entity<PizzasIngredients>(entity =>
            {
                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.PizzasIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaIngredient_Ingredients");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzasIngredients)
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("FK_PizzaIngredient_Pizzas");
            });
        }
    }
}
