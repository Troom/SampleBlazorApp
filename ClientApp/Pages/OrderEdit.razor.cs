﻿using ClientApp.Services;
using Domain.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shared;

namespace ClientApp.Pages
{
    public partial class OrderEdit
    {
        [Inject]
        public IOrderDataService? OrderDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }


        [Parameter]
        public string? OrderId { get; set; }
        public OrderDto OrderDto { get; set; } = new OrderDto();

        protected bool Saved;
        protected string Message = string.Empty;

        protected async override Task OnInitializedAsync()
        {
            Saved = false;
            int.TryParse(OrderId, out int orderId);
            if (orderId == 0) //new employee is being created
            {
                //add some defaults
                OrderDto = new OrderDto { ClientName = "BrakId", OrderPrice = 1, CreateDate = DateTime.Now, Status = OrderStatus.New };
            }
            else
            {
                OrderDto = await OrderDataService.GetOrderDetails(int.Parse(OrderId));
            }
        }

        protected async Task HandleValidSubmit() {

            Saved = false;
            if (OrderDto.OrderId == 0)
            {
                var addedOrder = await OrderDataService.AddOrder(OrderDto);
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
                await OrderDataService.UpdateOrder(OrderDto);
                Message = "Order updated successfully";
                Saved = true;
            }

            //var addedOrder = await OrderDataService.AddOrder(OrderDto);


        }


        protected async Task DeleteOrder()
        {
            await OrderDataService.DeleteOrder(Convert.ToInt32(OrderDto.OrderId));

            Message = "Deleted successfully";

            Saved = true;
        }

        protected async Task HandleInvalidSubmit()
        {
            Message = "Something was wrong. Check data and try again";

        }

        protected void NavigateToOverview() {

            NavigationManager.NavigateTo("/ordersoverview");
        }

        //private void OnInputFileChange(InputFileChangeEventArgs e)
        //{
        //    selectedFile = e.File;
        //    StateHasChanged();
        //}

    }
}
