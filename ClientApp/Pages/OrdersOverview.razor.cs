using ClientApp.Services;
using Microsoft.AspNetCore.Components;
using Shared;

namespace ClientApp.Pages
{
    public partial class OrdersOverview
    {
        [Inject]
        public IOrderDataService? OrderDataService { get; set; }

        public List<OrderDto> AllOrders { get; set; } = default!;
        public List<OrderDto> Orders { get; set; } = default!;
        private OrderDto? _selectedOrder;

        private string Title = "Orders overview";

        public int PageNumber { get; set; } = 1;
        const int Offset = 10;
        public int NumberOfOrders;


        protected override async Task OnInitializedAsync()
        {
            AllOrders = (await OrderDataService.GetAllOrders()).ToList();
            Orders = AllOrders.Skip((PageNumber-1)*Offset).Take(Offset).ToList();
            NumberOfOrders = AllOrders.Count;
        }

        public void ShowViewPopup(OrderDto selectedOrder) { 
            _selectedOrder = selectedOrder;
        }

        public void PreviousPage()
        {
            if ((PageNumber-1) >= 1)
            {
                PageNumber--;
                Orders = AllOrders.Skip((PageNumber - 1) * Offset).Take(Offset).ToList();
            }
        }

        public void NextPage()
        {
            if (PageNumber <= AllOrders.Count/Offset)
            {
                PageNumber++;
                Orders = AllOrders.Skip((PageNumber - 1) * Offset).Take(Offset).ToList();
            }
        }
    }
}
