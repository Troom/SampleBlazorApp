using Application.AppModel;
using Application.Mappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Queries
{
    public class GetOrdersQueryHandler : BaseOrderHandler, IRequestHandler<GetOrdersQuery, Response>
    {
        public GetOrdersQueryHandler(OrderContext context) : base(context)
        {
        }

        public async Task<Response> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            var orders = _context.Order.Include(x => x.OrderLines).AsQueryable();
            var orderList = await orders.ToListAsync();
            var result = new List<OrderDto>();

            foreach (var item in orderList)
            {
                result.Add(OrderDtoMapper.MapToOrderDto(item));
            }
            return new Response(result);
        }
    }
}