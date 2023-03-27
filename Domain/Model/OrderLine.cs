using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    public class OrderLine
    {
        [Key]
        public int Id { get; set; }

        public string Product { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public long OrderId { get; set; }
    }
}