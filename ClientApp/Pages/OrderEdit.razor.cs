using ClientApp.Helper;
using ClientApp.Model;
using ClientApp.Services;
using Domain.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shared;

namespace ClientApp.Pages
{
    public partial class OrderEdit
    {
        #region Config
        [Inject]
        public IOrderDataService? OrderDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string? OrderId { get; set; }
        public OrderDto OrderDto { get; set; } = new OrderDto() { OrderLines = new List<OrderLineDto>() };


        InputOrder Model = new InputOrder();
        bool Success;
        public string CurrentProduct { get; set; }
        public decimal CurrentPrice { get; set; }

        protected bool Saved;
        protected string Message = string.Empty;



        protected async override Task OnInitializedAsync()
        {
            //Saved = false;
            int.TryParse(OrderId, out int orderId);
            if (orderId == 0) //new order is being created
            {
                //add some defaults
                OrderDto = new OrderDto { ClientName = "SampleClientName", OrderPrice = 1, CreateDate = DateTime.Now, Status = OrderStatus.New, OrderLines = new List<OrderLineDto>() };
            }
            else
            {
                OrderDto = await OrderDataService.GetOrderDetails(int.Parse(OrderId));

                if (OrderDto.ClientName != null)
                {
                    Model = new InputOrder()
                    {
                        ClientName = OrderDto.ClientName,
                        CreateDate = OrderDto.CreateDate,
                        Status = OrderDto.Status,
                        AdditionalInfo = OrderDto.AdditionalInfo,
                        OrderLines = OrderDto.OrderLines
                    };
                    if (Model.Status != OrderStatus.New)
                    {
                        NavigationManager.NavigateTo("/ordersoverview");
                    }
                }
            }
        }

        #endregion


        #region FormHandling
        public void AddOrderLine()
        {
            if (CurrentPrice > 0)
            {
                OrderDto.OrderLines.Add(new OrderLineDto() { 
                    Product = CurrentProduct, Price = CurrentPrice });
                    OrderDto.OrderPrice = OrderDto.OrderLines.Sum(x => x.Price);
                    Model.OrderPrice = OrderDto.OrderLines.Sum(x => x.Price);
                    Model.OrderLines = OrderDto.OrderLines;
                    CurrentProduct = string.Empty;
            }
            CurrentPrice = 0;
        }

        public void RemoveProductsFromForm()
        {
            OrderDto.OrderLines.Clear();
            OrderDto.OrderPrice = OrderDto.OrderLines.Sum(x => x.Price);
            Model.OrderPrice = OrderDto.OrderLines.Sum(x => x.Price);
        }


        private async void OnValidSubmit(EditContext context)
        {
            Success = true;
            StateHasChanged();
            await HandleValidSubmit();
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            var submitOrder = new OrderDto()
            {
                OrderId = OrderDto.OrderId,
                CreateDate = Model.CreateDate ?? new DateTime(), //Error 
                ClientName = Model.ClientName,
                OrderPrice = Model.OrderPrice ?? 0, //Error
                OrderLines = Model.OrderLines,
                Status = Model.Status
            };


            if (submitOrder.OrderId == 0)
            {
                var addedOrder = await OrderDataService.AddOrder(submitOrder);
                if (addedOrder != null)
                {
                    Saved = true;
                }
                else
                {
                    Saved = false;
                }
            }
            else
            {
                await OrderDataService.UpdateOrder(submitOrder);
                Message = "Order updated successfully";
                Saved = true;
            }

            NavigateToOverview();
        }


        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/ordersoverview");
        }
        #endregion


    }
}