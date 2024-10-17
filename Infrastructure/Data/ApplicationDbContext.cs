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
                .HasOne(x => x.ShoppingCart)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ShoppingCartId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(x => x.Product)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<ShoppingCartProduct>()
                .HasOne(x => x.ShoppingCart)
                .WithMany(x => x.ShoppingCartProducts)
                .HasForeignKey(x => x.ShoppingCartId);

            modelBuilder.Entity<ShoppingCartProduct>()
                .HasOne(x => x.Product)
                .WithMany(x => x.ShoppingCartItems)
                .HasForeignKey(x => x.ProductId);
        }

    }


}
