using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public interface IOrderRepository : IDisposable
    {
        IQueryable All();
        Task<IEnumerable<Order>> GetOrders();
        Order GetOrderByID(long orderId);
        Task<long> InsertOrder(Order order);
        void DeleteOrder(long orderID);
        void UpdateOrder(Order order);
        void Save();
    }

    public class OrderRepository : IOrderRepository
    {
        private OrderContext context;
        public OrderRepository(OrderContext context)
        {
            this.context = context;
        }

        public IQueryable All()
        {
            return context.Order.AsQueryable(); // hmm?
        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await context.Order.ToListAsync();
        }

        public Order GetOrderByID(long orderId)
        {
            return context.Order.Find(orderId);
        }

        public async Task<long> InsertOrder(Order order)
        {
            await context.Order.AddAsync(order);
            await context.SaveChangesAsync();
            return order.Id;
        }

        public void DeleteOrder(long orderId)
        {
            Order order = context.Order.Find(orderId);
            context.Order.Remove(order);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            context.Entry(order).State = EntityState.Modified;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}