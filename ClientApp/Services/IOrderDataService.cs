
using Shared;

namespace ClientApp.Services
{
    public interface IOrderDataService
    {
        Task<IEnumerable<OrderDto>> GetAllOrders(bool refreshRequired = false);
        Task<OrderDto> GetOrderDetails(int orderId);
        Task<OrderDto> AddOrder(OrderDto order);
        Task UpdateOrder(OrderDto order);
        Task DeleteOrder(int orderId);
    }
}
