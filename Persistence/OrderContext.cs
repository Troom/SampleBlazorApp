using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Xml;

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

            modelBuilder.Entity<Order>().Property(p => p.OrderPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<OrderLine>().Property(p => p.Price).HasColumnType("decimal(18,2)");



            modelBuilder.Entity<Order>().HasData(
                new Order(){
                    Id = 1,
                    OrderPrice = 2,
                    ClientName = "John",
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 2,
                    ClientName = "Client2",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now.AddDays(-1),
                    Status = OrderStatus.Confirm
                }
                ,
                new Order()
                {
                    Id = 3,
                    ClientName = "Client3",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now.AddDays(-2),
                    Status = OrderStatus.Delivery
                },
                new Order()
                {
                    Id = 4,
                    ClientName = "Client4",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now.AddDays(-3),
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 5,
                    ClientName = "Client5",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now.AddDays(-4),
                    Status = OrderStatus.Confirm
                },
                new Order()
                {
                    Id = 6,
                    ClientName = "Client6",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now.AddDays(-5),
                    Status = OrderStatus.Delivery
                },
                new Order()
                {
                    Id = 7,
                    ClientName = "Client7",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now.AddDays(-6),
                    Status = OrderStatus.Confirm
                },
                new Order()
                {
                    Id = 8,
                    ClientName = "Client8",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now.AddDays(-7),
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 9,
                    ClientName = "Client9",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now.AddDays(-8),
                    Status = OrderStatus.Cancel
                },
                new Order()
                {
                    Id = 10,
                    ClientName = "Client10",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now.AddDays(-9),
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 11,
                    ClientName = "Client11",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now.AddDays(-10),
                    Status = OrderStatus.Confirm
                },
                new Order()
                {
                    Id = 12,
                    ClientName = "Client12",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now.AddDays(-11),
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 13,
                    ClientName = "Client13",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now.AddDays(-12),
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 14,
                    ClientName = "Client14",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now.AddDays(-13),
                    Status = OrderStatus.Confirm
                },
                new Order()
                {
                    Id = 15,
                    ClientName = "Client15",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now.AddDays(-14),
                    Status = OrderStatus.New
                },
                new Order()
                {
                    Id = 16,
                    ClientName = "Client16",
                    OrderPrice = 1,
                    CreateDate = DateTime.Now.AddDays(-15),
                    Status = OrderStatus.Cancel
                }
            );




            modelBuilder.Entity<OrderLine>().HasData(
                new OrderLine() { Id =1,OrderId = 1, Product = "P1", Price = 1 },
                new OrderLine() { Id= 2, OrderId = 1, Product = "P2", Price = 1 },
                new OrderLine() { Id = 3, OrderId = 2, Product = "P2", Price = 1 },
                new OrderLine() { Id = 4, OrderId = 3, Product = "P2", Price = 1 },
                new OrderLine() { Id = 5, OrderId = 4, Product = "P2", Price = 1 },
                new OrderLine() { Id = 6, OrderId = 5, Product = "P2", Price = 1 },
                new OrderLine() { Id = 7, OrderId = 6, Product = "P2", Price = 1 },
                new OrderLine() { Id = 8, OrderId = 7, Product = "P2", Price = 1 },
                new OrderLine() { Id = 9, OrderId = 8, Product = "P2", Price = 1 },
                new OrderLine() { Id = 10, OrderId = 9, Product = "P2", Price = 1 },
                new OrderLine() { Id = 11, OrderId = 10, Product = "P2", Price = 1 },
                new OrderLine() { Id = 12, OrderId = 11, Product = "P2", Price = 1 },
                new OrderLine() { Id = 13, OrderId = 12, Product = "P2", Price = 1 },
                new OrderLine() { Id = 14, OrderId = 13, Product = "P2", Price = 1 },
                new OrderLine() { Id = 15, OrderId = 14, Product = "P2", Price = 1 },
                new OrderLine() { Id = 16, OrderId = 15, Product = "P2", Price = 1 },
                new OrderLine() { Id = 17, OrderId = 16, Product = "P2", Price = 1 }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
