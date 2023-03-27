using Application.AppModel;
using Domain.Model;
using MediatR;

namespace Application.Commands.Create
{
    public class CreateOrderCommand : IRequest<Response>
    {
        public DateTime CreateDate { get; set; }
        public OrderStatus Status { get; set; }
        public string ClientName { get; set; }
        public decimal OrderPrice { get; set; }
        public string? AdditionalInfo { get; set; }
        public ICollection<OrderLineDto>? OrderLines { get; set; } = new List<OrderLineDto>();
    }
}
