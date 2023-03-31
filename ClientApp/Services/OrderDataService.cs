using Blazored.LocalStorage;
using ClientApp.Helper;
using Domain.Model;
using Shared;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace ClientApp.Services
{
    public class OrderDataService : IOrderDataService
    {

        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public OrderDataService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public async Task<OrderDto> AddOrder(OrderDto order)
        {

            var orderJson = new StringContent(JsonSerializer.Serialize(order),
                Encoding.UTF8,"application/json");

            var response = await _httpClient.PostAsync("/order/createorder/create", orderJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<OrderDto>(await
                    response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdateOrder(OrderDto order)
        {
            var orderJson = new StringContent(JsonSerializer.Serialize(order),
                Encoding.UTF8, "application/json");

           var x = await _httpClient.PutAsync("/order/updateorder", orderJson);
        }

        public async Task DeleteOrder(int orderId)
        {
            await _httpClient.DeleteAsync($"order/deleteorder/{orderId}");
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrders(bool refreshRequired = false)
        {
            if (!refreshRequired)
            {
                bool orderExpirationExist = await _localStorageService
                    .ContainKeyAsync(LocalStorageConstants.OrdersListExpirationKey);
                if (orderExpirationExist)
                {
                    DateTime orderListExpiration = await _localStorageService.GetItemAsync<DateTime>
                        (LocalStorageConstants.OrdersListExpirationKey);
                    if (orderListExpiration > DateTime.Now)
                    {
                        if (await _localStorageService.ContainKeyAsync
                            (LocalStorageConstants.OrdersListKey))
                        {
                            return await _localStorageService.GetItemAsync
                                <List<OrderDto>>(LocalStorageConstants.OrdersListKey);
                        }
                    }
                }
            }

            var list = await JsonSerializer.DeserializeAsync<IEnumerable<OrderDto>>
                (await _httpClient.GetStreamAsync($"/order/getorders"), 
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            await _localStorageService.SetItemAsync
                (LocalStorageConstants.OrdersListExpirationKey, list);
            await _localStorageService.SetItemAsync (LocalStorageConstants.OrdersListExpirationKey, DateTime.Now.AddMinutes(1));

            return list;

        }
        public async Task<OrderDto> GetOrderDetails(int orderId)
        {
            return await JsonSerializer.DeserializeAsync<OrderDto>
                (await _httpClient.GetStreamAsync($"/order/getorder/{orderId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

 
    }
}
