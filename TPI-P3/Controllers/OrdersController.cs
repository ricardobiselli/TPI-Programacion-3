using Application.Interfaces;
using Application.Models;
using Application.Services;
using Domain.Models.Purchases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            var order = _orderService.PlaceAnOrderFromCartContent(userId);

            if (order!= null && IsClient())
            {
                var orderDto = OrderDTO.Create(order);
                return Ok("Order confirmed successfully!");
            }
            return BadRequest("Warning! Failed to confirm order");
        }

        [HttpGet("Get-My-Orders")]
        public ActionResult<List<OrderDTO>> GetMyOrders()
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");

            if (!IsClient())
            {
                return Forbid();
            }

            var orders = _orderService.GetOrdersByClientId(userId);

            if (orders == null || orders.Count == 0)
            {
                return NotFound("No orders found for this client.");
            }

            var listOfOrders = orders
                .Select(OrderDTO.Create)
                .ToList();

            return Ok(listOfOrders);
        }

        [HttpGet("Get-All")]
        public ActionResult <List<OrderDTO>> GetAllOrders()
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }

            var orders = _orderService.GetAll();

            if (orders == null || orders.Count == 0)
            {
                return NotFound();
            }

            var listOfOrders = orders
            .Select(OrderDTO.Create)
            .ToList();
            return Ok(listOfOrders);
        }

        [HttpGet("Get-Order-By-Id")]
        public ActionResult<OrderDTO>GetById(int id)
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }

            var order = _orderService.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            var orderDto = OrderDTO.Create(order);
            return Ok(orderDto);
        }

        [HttpDelete("Delete-Order/{id}")]
        public ActionResult Delete(int id)
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }

            var order = _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            _orderService.Delete(id);
            return NoContent();
        }
    }
}