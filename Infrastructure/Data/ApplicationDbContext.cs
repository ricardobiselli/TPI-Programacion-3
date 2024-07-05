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
        //public DbSet<Payment> Payments { get; set; }
        //public DbSet<Compatibility> Compatibilities { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<SuperAdmin> SuperAdmins { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<ShoppingCart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                //modelBuilder.Entity<Product>()
                //    .HasMany(p => p.Compatibilities)
                //    .WithOne()
                //    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Client>()
                    .HasMany(c => c.Orders)
                    .WithOne(o => o.Client)
                    .HasForeignKey(o => o.ClientId)
                    .OnDelete(DeleteBehavior.Cascade);

                //modelBuilder.Entity<Client>()
                //    .HasMany(c => c.Payments)
                //    .WithOne(p => p.Client)
                //    .HasForeignKey(p => p.ClientId)
                //    .OnDelete(DeleteBehavior.Cascade);

                //modelBuilder.Entity<Client>()
                //    .HasOne(c => c.Cart)
                //    .WithOne(sc => sc.Client)
                //    .HasForeignKey<ShoppingCart>(sc => sc.ClientId)
                //    .OnDelete(DeleteBehavior.Cascade);

                //modelBuilder.Entity<ShoppingCart>()
                //    .HasMany(sc => sc.Products)
                //    .WithMany(p => p.ShoppingCarts)
                //    .UsingEntity<Dictionary<string, object>>(
                //        "CartProduct",
                //        j => j
                //            .HasOne<Product>()
                //            .WithMany()
                //            .HasForeignKey("ProductId")
                //            .OnDelete(DeleteBehavior.Cascade),
                //        j => j
                //            .HasOne<ShoppingCart>()
                //            .WithMany()
                //            .HasForeignKey("CartId")
                //            .OnDelete(DeleteBehavior.Cascade),
                //        j =>
                //        {
                //            j.HasKey("CartId", "ProductId");
                //            j.ToTable("CartProduct");
                //        });

                modelBuilder.Entity<Order>()
                    .HasMany(o => o.Products)
                    .WithMany(p => p.Orders)
                    .UsingEntity<Dictionary<string, object>>(
                        "OrderProduct",
                        j => j
                            .HasOne<Product>()
                            .WithMany()
                            .HasForeignKey("ProductId")
                            .OnDelete(DeleteBehavior.Cascade),
                        j => j
                            .HasOne<Order>()
                            .WithMany()
                            .HasForeignKey("OrderId")
                            .OnDelete(DeleteBehavior.Cascade),
                        j =>
                        {
                            j.HasKey("OrderId", "ProductId");
                            j.ToTable("OrderProduct");
                        });

                base.OnModelCreating(modelBuilder);
            }

        }

    }
}
