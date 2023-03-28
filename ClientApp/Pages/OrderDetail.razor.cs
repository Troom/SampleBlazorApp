using ClientApp.Services;
using Microsoft.AspNetCore.Components;
using Shared;

namespace ClientApp.Pages
{
    public partial class OrderDetail
    {
        [Inject]
        public IOrderDataService OrderDataService { get; set; }

        [Parameter]
        public string OrderId { get; set; }
        public OrderDto? Order { get; set; } = new OrderDto();
        protected async override Task OnInitializedAsync()
        { 
            Order = await OrderDataService.GetOrderDetails(int.Parse(OrderId));
        }
    }
}
