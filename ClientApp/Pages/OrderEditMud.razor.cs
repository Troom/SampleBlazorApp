using ClientApp.Services;
using Domain.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shared;
using System.ComponentModel.DataAnnotations;

namespace ClientApp.Pages
{
    public partial class OrderEditMud
    {
        [Inject]
        public IOrderDataService? OrderDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string? OrderId { get; set; }
        public OrderDto OrderDto { get; set; } = new OrderDto() { OrderLines = new List<OrderLineDto>() };



        InputOrder model = new InputOrder();
        bool success;

        public string currentProduct { get; set; }
        public decimal currentPrice { get; set; }


        public void AddOrderLine() {
            OrderDto.OrderLines.Add(new OrderLineDto() { Product = currentProduct, Price = currentPrice });
            OrderDto.OrderPrice = OrderDto.OrderLines.Sum(x => x.Price);
            model.OrderPrice = OrderDto.OrderLines.Sum(x => x.Price);
            currentProduct = string.Empty;
            currentPrice = 0;
        }

        public void RemoveProducts()
        {
            OrderDto.OrderLines.Clear();
            OrderDto.OrderPrice = OrderDto.OrderLines.Sum(x => x.Price);
            model.OrderPrice = OrderDto.OrderLines.Sum(x => x.Price);
        }

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

            public decimal? OrderPrice { get; set; } //Zapodawana z automatu

            public ICollection<OrderLineDto>? OrderLines { get; set; }

            public string? AdditionalInfo { get; set; }
        }

        private void OnValidSubmit(EditContext context)
        {
            success = true;
            StateHasChanged();
        }
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
                    model = new InputOrder()
                    {
                        ClientName = OrderDto.ClientName,
                        CreateDate = OrderDto.CreateDate,
                        Status = OrderDto.Status,
                        AdditionalInfo = OrderDto.AdditionalInfo,
                        OrderLines = OrderDto.OrderLines
                    };
                }
            }
        }

    }
}
