using Application.AppModel;
using Domain.Model;
using MediatR;
using Shared;

namespace Application.Commands.Update
{
    public class UpdateOrderCommand : IRequest<Response>
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public OrderStatus Status { get; set; }
        public string ClientName { get; set; }
        public decimal OrderPrice { get; set; }
        public string? AdditionalInfo { get; set; }
        public ICollection<OrderLineDto>? OrderLines { get; set; } = new List<OrderLineDto>();


        public void SetOrderId(long id)
        {
            Id = id;
        }

    }
}
