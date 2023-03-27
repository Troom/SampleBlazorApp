using Application.AppModel;
using Domain.Model;

namespace Application.Mappers
{
    public static class OrderDtoMapper
    {
        public static OrderDto MapToOrderDto(Order order)
        {
            List<OrderLineDto> orderLineList = new List<OrderLineDto>();

            foreach (var item in order.OrderLines)
            {
                orderLineList.Add(new OrderLineDto()
                {
                    Product = item.Product,
                    Price = item.Price
                });
            }
            var result = new OrderDto()
            {
                ClientName = order.ClientName,
                Status = order.Status,
                CreateDate = order.CreateDate,
                AdditionalInfo = order.AdditionalInfo,
                OrderLines = orderLineList
            };
            return result;
        }
    }
}
