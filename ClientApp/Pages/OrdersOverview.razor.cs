using ClientApp.Services;
using Microsoft.AspNetCore.Components;
using Shared;

namespace ClientApp.Pages
{
    public partial class OrdersOverview
    {
        [Inject]
        public IOrderDataService? OrderDataService { get; set; }

        public List<OrderDto> Orders { get; set; } = default!;
        private OrderDto? _selectedOrder;

        private string Title = "Orders overview";

        protected override async Task OnInitializedAsync()
        {
            Orders = (await OrderDataService.GetAllOrders()).ToList();
        }

        public void ShowViewPopup(OrderDto selectedOrder) { 
            _selectedOrder = selectedOrder;
        }
    }
}
