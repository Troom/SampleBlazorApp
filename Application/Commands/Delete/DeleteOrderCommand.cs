using MediatR;

namespace Application.Commands.Delete
{
    public class DeleteOrderCommand : IRequest<Response>
    {
        public long Id { get; set; }


        public DeleteOrderCommand(long orderId)
        {
            Id = orderId;
        }
    }
}
