using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Place-Order")]
        public ActionResult ConfirmOrder(int clientId)
        {
            var response = _orderService.PlaceAnOrderFromCartContent(clientId);
            if (response)
            {
                return Ok("Order confirmed successfully!");
            }
            return BadRequest("Warning! Failed to confirm order");
        }

        [HttpGet]
        public ActionResult GetAllOrders()
        {
            var orders = _orderService.GetAll();
            return Ok(orders);
        }

        [HttpGet("Get-One")]
        public ActionResult GetById(int id)
        {
            var order = _orderService.GetById(id);
            return Ok(order);
        }


    }
}