
using Shared;

namespace ClientApp.Services
{
    public interface IOrderDataService
    {
        Task<IEnumerable<OrderDto>> GetAllOrders(bool refreshRequired = false);
        Task<OrderDto> GetOrderDetails(int employeeId);
        Task<OrderDto> AddOrder(OrderDto employee);
        Task UpdateOrder(OrderDto employee);
        Task DeleteOrder(int employeeId);
    }
}
