using Domain.Model;
using MediatR;
using Persistence;

namespace Application.Commands.Update
{
    public class UpdateOrderCommandHandler : BaseOrderHandler, IRequestHandler<UpdateOrderCommand, Response>
    {
        public UpdateOrderCommandHandler(OrderContext context) : base(context)
        {
        }

        public async Task<Response> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await GetOrderById(command.Id);
            UpdateOrder(order, command);
            await _context.SaveChangesAsync();

            return new Response();
        }

        private void UpdateOrder(Order order, UpdateOrderCommand command)
        {
            List<OrderLine> x = new List<OrderLine>();
            if (command.OrderLines != null)
            {
                foreach (var item in command.OrderLines)
                {
                    x.Add(new OrderLine() { Product = item.Product, 
                                            Price = item.Price }
                                            );
                }
            }

            order.ClientName = command.ClientName;
            order.OrderPrice = command.OrderPrice;
            order.AdditionalInfo = command.AdditionalInfo;
            order.CreateDate = command.CreateDate;
            order.Status = command.Status;
            order.OrderLines = x;
        }
    }
}