using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Compatibility> Compatibilities { get; set; }
        public DbSet<AdminClass> Admins { get; set; }
        public DbSet<SuperAdmin> SuperAdmins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingCart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - AdminClass - SuperAdmin
           /*modelBuilder.Entity<AdminClass>()
                .HasOne(a => a.User)
                .WithOne()
                .HasForeignKey<AdminClass>(a => a.Id);

            modelBuilder.Entity<SuperAdmin>()
                .HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<SuperAdmin>(s => s.Id);
           

            // Client - Order
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Client)
                .HasForeignKey(o => o.ClientId);

            // Order - Product
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithOne(p => p.Order)
                .HasForeignKey(p => p.OrderId);

            // Product - Compatibility
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Compatibilities)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductId);

            // Product - ShoppingCart
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ShoppingCart)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.ShoppingCartId);
           */
        }
    }
}
