using Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Persistence;

namespace Application.Commands.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response>
    {
        private readonly OrderContext _context;

        public CreateOrderCommandHandler(OrderContext orderContext)
        {
            _context = orderContext;
        }

        public async Task<Response> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
                return new Response(StatusCodes.Status400BadRequest);

            var order = MapOrder(command);
            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();

            return new Response(new { id = order.Id });
        }

        private Order MapOrder(CreateOrderCommand command)
        {
            return new Order() {
                ClientName = command.ClientName,
                Status = command.Status,
                CreateDate = command.CreateDate,
                OrderLines = command.OrderLines.Select(x=>new OrderLine() { 
                                                        Product = x.Product,
                                                        Price = x.Price
                                                        }).ToList(),
                OrderPrice = command.OrderPrice,
                AdditionalInfo = command.AdditionalInfo
            };

        }
    }
}