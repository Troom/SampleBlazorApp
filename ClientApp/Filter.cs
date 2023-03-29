using Domain.Model;
using System.ComponentModel;

namespace ClientApp
{
    public class OrderFilter
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public IEnumerable<OrderStatus> Statuses { get; set; } = Enumerable.Empty<OrderStatus>();
    }
}
