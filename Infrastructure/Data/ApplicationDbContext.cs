using Microsoft.EntityFrameworkCore;
using Domain.Models.Users;
using Domain.Models.Purchases;
using Domain.Models.Products;

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
        public DbSet<Admin> Admins { get; set; }
        public DbSet<SuperAdmin> SuperAdmins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ShoppingCart>()
                .HasOne(sc => sc.Client)
                .WithOne(c => c.ShoppingCart)
                .HasForeignKey<ShoppingCart>(sc => sc.ClientId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.ShoppingCart)
                .WithMany(sc => sc.Orders)
                .HasForeignKey(o => o.ShoppingCartId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.ProductId);

            modelBuilder.Entity<ShoppingCartProduct>()
                .HasOne(scp => scp.ShoppingCart)
                .WithMany(sc => sc.ShoppingCartProducts)
                .HasForeignKey(scp => scp.ShoppingCartId);

            modelBuilder.Entity<ShoppingCartProduct>()
                .HasOne(scp => scp.Product)
                .WithMany(p => p.ShoppingCartItems)
                .HasForeignKey(scp => scp.ProductId);
        }

    }


}
