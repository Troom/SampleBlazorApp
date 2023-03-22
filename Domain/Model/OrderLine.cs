namespace Domain.Model
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public long OrderId { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; }
    }
}
