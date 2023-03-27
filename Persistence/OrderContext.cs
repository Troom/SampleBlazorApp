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
                new Order(){
                    Id = 1,
                    OrderPrice = 1,
                    ClientName = "John",
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 2,
                    ClientName = "Client2",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 3,
                    ClientName = "Client3",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 4,
                    ClientName = "Client4",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 5,
                    ClientName = "Client5",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 6,
                    ClientName = "Client6",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 7,
                    ClientName = "Client7",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 8,
                    ClientName = "Client8",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 9,
                    ClientName = "Client9",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 10,
                    ClientName = "Client10",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 11,
                    ClientName = "Client11",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 12,
                    ClientName = "Client12",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 13,
                    ClientName = "Client13",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 14,
                    ClientName = "Client14",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 15,
                    ClientName = "Client15",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 16,
                    ClientName = "Client16",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                }
            );




            modelBuilder.Entity<OrderLine>().HasData(
                new OrderLine() { Id =1,OrderId = 1, Product = "P1", Price = 1 },
                new OrderLine() { Id= 2, OrderId = 2, Product = "P2", Price = 2 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
