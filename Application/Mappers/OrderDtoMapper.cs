﻿using Application.AppModel;
using Domain.Model;
using Shared;

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
                OrderId = order.Id,
                ClientName = order.ClientName,
                Status = order.Status,
                CreateDate = order.CreateDate,
                AdditionalInfo = order.AdditionalInfo,
                OrderPrice = order.OrderLines.Sum(x=>x.Price),
                OrderLines = orderLineList
            };
            return result;
        }
    }
}
