using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<OrderLine>().ToTable("OrderLine");
        }
    }
}
