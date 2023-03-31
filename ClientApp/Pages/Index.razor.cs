using ClientApp.Helper;
using ClientApp.Services;
using Domain.Model;
using Microsoft.AspNetCore.Components;
using Shared;

namespace ClientApp.Pages
{
    public partial class Index
    {
        [Inject]
        public ApplicationState ApplicationState { get; set; }
        [Inject]
        public IOrderDataService? OrderDataService { get; set; }

        private IEnumerable<OrderDto> AllElements = new List<OrderDto>();
        protected override async Task OnInitializedAsync()
        {
            AllElements = (await OrderDataService.GetAllOrders()).ToList();
            ApplicationState.NewOrders = AllElements.Where(x => x.Status == OrderStatus.New).Count();
            StateHasChanged();
        }
    }
}
