using Application.Commands.Create;
using Application.Commands.Delete;
using Application.Commands.Update;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(
                IMediator mediator
            ){
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetOrder(int id)
        {
            try
            {
                var order = await _mediator.Send(new GetOrderQuery(id));
                return Ok(order.Result);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message); //User nie moze dokladnei wiedziec co sie dzieje. Do zrefactorowania
            }
        }
        [HttpGet(Name = "GetOrders")]
        [AllowAnonymous]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var orderList = await _mediator.Send(new GetOrdersQuery());

                return Ok(orderList.Result);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message); //User nie moze dokladnei wiedziec co sie dzieje. Do zrefactorowania
            }
        }


        [HttpPost("Create")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand order)
        {
            try
            {
                var commandResult = await _mediator.Send(order);
                return Created("", commandResult);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(/*long id,*/ [FromBody] OrderDto orderDto)
        {
            try
            {
                //command.SetOrderId(id);
                var command = new UpdateOrderCommand() { ClientName = orderDto.ClientName,
                                                         CreateDate = orderDto.CreateDate,
                                                         AdditionalInfo = orderDto.AdditionalInfo,
                                                         OrderPrice = orderDto.OrderPrice,
                                                         Status = orderDto.Status,
                                                         Id = orderDto.OrderId,
                                                         OrderLines = orderDto.OrderLines
                                                            };
                await _mediator.Send(command);
                return Ok();
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(long id)
        {
            try
            {
                var command = new DeleteOrderCommand(id);
                await _mediator.Send(command);
                return Ok();
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}