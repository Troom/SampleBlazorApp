namespace Domain.Model
{
    public class Order
    {
        public Order() { }

        public long OrderId { get; set; }
        public DateTime CreateDate { get; set; }
        public OrderStatus Status { get; set; }
        public string ClientName { get; set; }
        public decimal OrderPrice { get; set; }
        public string? AdditionalInfo { get; set; }
        public ICollection<OrderLine>? OrderLines { get; set; }

    }
}
