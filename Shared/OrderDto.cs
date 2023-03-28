using Domain.Model;

namespace Shared
{
    public class OrderDto
    {
        public long OrderId { get; set; }
        public DateTime CreateDate { get; set; }
        public OrderStatus Status { get; set; }
        public string ClientName { get; set; }
        public decimal OrderPrice { get; set; }
        public string? AdditionalInfo { get; set; }
        public ICollection<OrderLineDto>? OrderLines { get; set; }
    }
}
