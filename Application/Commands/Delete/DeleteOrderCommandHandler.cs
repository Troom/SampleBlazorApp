using MediatR;
using Persistence;

namespace Application.Commands.Delete
{
    public  class DeleteOrderCommandHandler : BaseOrderHandler, IRequestHandler<DeleteOrderCommand, Response>
    {
        public DeleteOrderCommandHandler(OrderContext context) : base(context)
        {
        }
        public async Task<Response> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await GetOrderById(command.Id);
            _context.Remove(order);
            await _context.SaveChangesAsync();
            return new Response();
        }
    }
}