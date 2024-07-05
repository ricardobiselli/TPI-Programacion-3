using Application.Models;
using Domain.Models.Purchases;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace TPI_P3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDTO orderDTO)
        {
            try
            {
                var client = await _orderRepository.GetClientByIdAsync(orderDTO.ClientId);
                if (client == null)
                {
                    return NotFound("Client not found");
                }

                var products = await _orderRepository.GetProductsByIdsAsync(orderDTO.ProductIds);
                if (products.Count != orderDTO.ProductIds.Count)
                {
                    return BadRequest("One or more products not found");
                }

                var order = new Order(orderDTO.TotalAmount, orderDTO.ClientId)
                {
                    Products = products
                };

                await _orderRepository.AddOrderAsync(order);

                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetAllOrders(int clientId)
        {
            try
            {
                var orders = await _orderRepository.GetOrdersByClientIdAsync(clientId);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
