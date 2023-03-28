using Microsoft.AspNetCore.Components;
using Shared;

namespace ClientApp.Components
{
    public partial class OrderCard
    {
        [Parameter]
        public OrderDto Order { get; set; } = default;
        [Parameter]
        public EventCallback<OrderDto> OrderViewClicked { get; set; }

    }
}
