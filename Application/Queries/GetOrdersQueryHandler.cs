using Azure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Queries
{
    internal class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, Response>
    {
        private readonly OrderContext _context;

        public GetOrdersQueryHandler(OrderContext orderContext)
        {
            _context = orderContext;
        }


        public async Task<Response> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            var orders = _context.Order.Include(x => x.OrderLines).AsQueryable();

            var orderList = await orders.ToListAsync();

            return new Response(orderList);
        }


    }
}
