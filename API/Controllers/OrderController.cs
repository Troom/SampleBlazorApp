using Application.Queries;
using Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        public OrderController(
                IMediator mediator
            )
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;


        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetReservation(int id)
        {
            try
            {

                //var reservation = await _reservationRepository.GetReservation(id);
                var order = new Order()
                {
                    CreateDate = DateTime.Now,
                    Status = OrderStatus.New,
                    OrderPrice = 10,
                    OrderLines = new List<OrderLine>(),
                    ClientName = "XYZ"
                };

                return Ok(order);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message); //User nie moze tego wiedziec do zrefactorowania
            }
        }
        [HttpGet(Name = "GetReservations")]
        [AllowAnonymous]
        public IActionResult GetReservations()
        {
            try
            {
                //var reservationList = _reservationRepository.GetReservations();
                //var orderList = new List<Order>();

                var orderList = _mediator.Send(new GetOrdersQuery());

                return Ok(orderList);
                //return Ok(orderList.Result);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message); //User nie moze tego wiedziec do zrefactorowania
            }
        }


        //[HttpPost("Create")]
        //public IActionResult CreateOrder([FromBody] Order order)
        //{
        //    // TODO Reservation musi pobierac customerId z zalogowanego usera.
        //    try
        //    {
        //        _reservationRepository.InsertReservation(reservation);
        //        return Ok();
        //    }
        //    catch (ApplicationException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] Reservation reservation)
        //{
        //    try
        //    {
        //        await _reservationRepository.UpdateReservation(reservation);
        //        return Ok();
        //    }
        //    catch (ApplicationException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}



        //[HttpDelete("{id}")]
        //public IActionResult DeleteReservation(int id)
        //{
        //    try
        //    {
        //        _reservationRepository.DeleteReservation(id);
        //        return Ok();
        //    }
        //    catch (ApplicationException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}