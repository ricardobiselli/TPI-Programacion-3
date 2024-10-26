using Application.Exceptions;
using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TPI_P3.Controllers;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : RoleCheckController
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Place-Order")]
        public ActionResult ConfirmOrder()
        {
            try
            {
                var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                var order = _orderService.PlaceAnOrderFromCartContent(userId);
                if (IsClient())
                {
                    var orderDto = OrderDTO.Create(order);
                    return Ok("Order confirmed successfully!");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (ValidateException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (ServiceException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpGet("Get-My-Orders")]
        public ActionResult<List<ShowOrdersToClientDTO>> GetMyOrders()
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");

            if (!IsClient())
            {
                return Forbid();
            }
            try
            {
                var orders = _orderService.GetOrdersByClientId(userId);
                var listOfOrders = orders
                    .Select(ShowOrdersToClientDTO.Create)
                    .ToList();
                if (listOfOrders.Count == 0)
                {
                    return NotFound(new { message = "No active orders for this client" });
                }
                return Ok(listOfOrders);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }



        }

        [HttpGet("Get-All")]
        public ActionResult<List<OrderDTO>> GetAllOrders()
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }

            var orders = _orderService.GetAll();
            var listOfOrders = orders
            .Select(OrderDTO.Create)
            .ToList();

            if (!listOfOrders.Any())
            {
                return NotFound(new { message = "No Orders found" });
            }
            return Ok(listOfOrders);
        }

        [HttpGet("Get-Order-By-Id")]
        public ActionResult<OrderDTO> GetById(int id)
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }

            try
            {
                var order = _orderService.GetById(id);
                var orderDto = OrderDTO.Create(order);
                return Ok(orderDto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }

        [HttpDelete("Delete-Order/{id}")]
        public ActionResult Delete(int id)
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }
            try
            {
                var order = _orderService.GetById(id);
                _orderService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}