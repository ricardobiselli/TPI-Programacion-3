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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                

                modelBuilder.Entity<Client>()
                    .HasMany(c => c.Orders)
                    .WithOne(o => o.Client)
                    .HasForeignKey(o => o.ClientId)
                    .OnDelete(DeleteBehavior.Cascade);

                

                


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
