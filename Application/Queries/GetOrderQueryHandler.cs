using Application.AppModel;
using Application.Mappers;
using Domain.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Queries
{
    public class GetOrderQueryHandler : BaseOrderHandler, IRequestHandler<GetOrderQuery, Response>
    {
        public GetOrderQueryHandler(OrderContext context) : base(context)
        {
        }
        public async Task<Response> Handle(GetOrderQuery query, CancellationToken cancellationToken)
        {

            var orders = _context.Order.Where(x => x.Id == query.Id).Include(x => x.OrderLines).AsQueryable();
            var orderList = await orders.ToListAsync();

            var order = orderList.FirstOrDefault();

            if (order != null)
            {
                OrderDto result = OrderDtoMapper.MapToOrderDto(order);
                return new Response(result);
            }

            return new Response();  
        }
    }
}
