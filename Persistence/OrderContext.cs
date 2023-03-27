using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Order {get;set;}
        public DbSet<OrderLine> OrderLines { get; set; }

        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    Id=1,
                    ClientName = "C1",
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                }
                ,
                new Order()
                {
                    Id = 2,
                    ClientName = "C2",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                }
            );

            modelBuilder.Entity<OrderLine>().HasData(
                new OrderLine() { Id = 1,OrderId = 1, Product = "P1", Price = 1 },
                new OrderLine() { Id= 2, OrderId = 2, Product = "P2", Price = 2 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
