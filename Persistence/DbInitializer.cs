using Domain.Model;

namespace Persistence
{
    public static class DbInitializer
    {
        public static void Initialize(OrderContext context)
        {
            context.Database.EnsureCreated();

            if (context.Order.Any())
            {
                return;
            }

            var orders = new Order[]
            {
            new Order{Id =1, Status = OrderStatus.New, CreateDate = DateTime.Now, OrderPrice = 1, ClientName = "X", AdditionalInfo = ""},
            new Order{Id =2, Status = OrderStatus.New, CreateDate = DateTime.Now, OrderPrice = 1, ClientName = "X", AdditionalInfo = ""},
            new Order{Id =3, Status = OrderStatus.New, CreateDate = DateTime.Now, OrderPrice = 1, ClientName = "X", AdditionalInfo = ""},
            new Order{Id =4, Status = OrderStatus.New, CreateDate = DateTime.Now, OrderPrice = 1, ClientName = "X", AdditionalInfo = ""},
            new Order{Id =5, Status = OrderStatus.New, CreateDate = DateTime.Now, OrderPrice = 1, ClientName = "X", AdditionalInfo = ""},
            new Order{Id =6, Status = OrderStatus.New, CreateDate = DateTime.Now, OrderPrice = 1, ClientName = "X", AdditionalInfo = ""},
            new Order{Id =7, Status = OrderStatus.New, CreateDate = DateTime.Now, OrderPrice = 1, ClientName = "X", AdditionalInfo = ""},
            new Order{Id =8, Status = OrderStatus.New, CreateDate = DateTime.Now, OrderPrice = 1, ClientName = "X", AdditionalInfo = ""},
            new Order{Id =9, Status = OrderStatus.New, CreateDate = DateTime.Now, OrderPrice = 1, ClientName = "X", AdditionalInfo = ""},
            new Order{Id =10, Status = OrderStatus.New, CreateDate = DateTime.Now, OrderPrice = 1, ClientName = "X", AdditionalInfo = ""},
            new Order{Id =11, Status = OrderStatus.New, CreateDate = DateTime.Now, OrderPrice = 1, ClientName = "X", AdditionalInfo = ""},
            new Order{Id =12, Status = OrderStatus.New, CreateDate = DateTime.Now, OrderPrice = 1, ClientName = "X", AdditionalInfo = ""},
            new Order{Id =13, Status = OrderStatus.New, CreateDate = DateTime.Now, OrderPrice = 1, ClientName = "X", AdditionalInfo = ""}
            };

            foreach (var item in orders)
            {
                context.Order.Add(item);
            }

            context.SaveChanges();

            var orderLines = new OrderLine[] {

                new OrderLine{ OrderId=1, Price = 1, Product = "Product" },
                new OrderLine{ OrderId=2, Price = 1, Product = "Product" },
                new OrderLine{ OrderId=2, Price = 1, Product = "Product" },
                new OrderLine{ OrderId=3, Price = 1, Product = "Product" },
                new OrderLine{ OrderId=3, Price = 1, Product = "Product" },
                new OrderLine{ OrderId=3, Price = 1, Product = "Product" }
            };

            foreach (var item in orderLines)
            {
                context.OrderLines.Add(item);
            }
            context.SaveChanges();
        }

    }
}




