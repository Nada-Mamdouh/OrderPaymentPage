using Microsoft.EntityFrameworkCore;
using OrderPaymentPageApi.Models;

namespace OrderPaymentPageApi.Data
{
    public class OrderPaymentDbContext:DbContext
    {
        
        public OrderPaymentDbContext(DbContextOptions<OrderPaymentDbContext> options):base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                        .Property(order => order.Total)
                        .HasComputedColumnSql("ItemPrice * Quantity", stored: true);
            modelBuilder.Entity<Order>()
                        .Property(order => order.DateOrdered)
                        .HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<Order>()
                        .HasIndex(order => order.Title)
                        .IsUnique();
            modelBuilder.Entity<Payment>()
                        .Property(payment => payment.DateCreated)
                        .HasDefaultValue(DateTime.Now);
        }
    }
}
