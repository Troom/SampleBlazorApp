using Domain.Model;
using Shared;
using System.ComponentModel.DataAnnotations;

namespace ClientApp.Model
{
    public class InputOrder
    {
        [Required]
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        TimeSpan? Time = DateTime.Now.TimeOfDay;

        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.New;

        [Required]
        [StringLength(40, ErrorMessage = "ClientName length can't be more than 40.")]
        public string ClientName { get; set; }

        public decimal? OrderPrice { get; set; }

        [Required(ErrorMessage = "Add some products to your order.")]
        public ICollection<OrderLineDto>? OrderLines { get; set; }

        public string? AdditionalInfo { get; set; }
    }
}
