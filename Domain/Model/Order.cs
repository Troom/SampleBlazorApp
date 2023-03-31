using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class Order
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public OrderStatus Status { get; set; }
        public string ClientName { get; set; } 
        public decimal OrderPrice { get; set; }
        public string? AdditionalInfo { get; set; } = "";
        public ICollection<OrderLine>? OrderLines { get; set; }

    }
}
