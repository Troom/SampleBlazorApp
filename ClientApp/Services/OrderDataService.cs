using Blazored.LocalStorage;
using ClientApp.Helper;
using Shared;
using System.Text.Json;

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

        public Task<OrderDto> AddOrder(OrderDto employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrder(int employeeId)
        {
            throw new NotImplementedException();
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

        public async Task<OrderDto> GetOrderDetails(int employeeId)
        {
            return await JsonSerializer.DeserializeAsync<OrderDto>
                (await _httpClient.GetStreamAsync($"/api/orders/{employeeId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public Task UpdateOrder(OrderDto employee)
        {
            throw new NotImplementedException();
        }
    }
}
