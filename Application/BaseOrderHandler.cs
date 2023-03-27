using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application
{
    public class BaseOrderHandler
    {
        protected readonly OrderContext _context;

        public BaseOrderHandler(OrderContext context) { 
            _context = context;
        }

        protected async Task<Order> GetOrderById(long id)
        {
            var order = await _context.Order
                .Include(e => e.OrderLines)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (order is null)
                throw new FileNotFoundException($"Order with id {id} doesnt exist"); //Todo change this exception. Currenly I don't have enough mana

            return order;
        }
    }
}
