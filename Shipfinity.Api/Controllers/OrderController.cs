using Microsoft.AspNetCore.Mvc;
using Serilog;
using Shipfinity.DTOs.OrderDTOs;
using Shipfinity.Services.Interfaces;
using System.Security.Claims;

namespace Shipfinity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IEmailService _emailService;

        public OrderController(IOrderService orderService, IEmailService emailService)
        {
            _orderService = orderService;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderReadDto>>> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrdersAsync();

                if (orders == null || !orders.Any())
                {
                    return NotFound("No orders found");
                }

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid order Id");
            }

            try
            {
                var order = await _orderService.GetOrderByIdAsync(id);

                if (order == null)
                {
                    return NotFound($"Order with Id {id} not found");
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<OrderReadDto>>> GetOrdersByUserId(int userId)
        {
            if (userId <= 0)
            {
                return BadRequest("Invalid user Id");
            }

            try
            {
                var orders = await _orderService.GetOrderByUserIdAsync(userId);

                if (orders == null || !orders.Any())
                {
                    return NotFound($"No orders found for user with Id {userId}");
                }

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("product/{productId}")]
        public async Task<ActionResult<List<OrderReadDto>>> GetOrdersByProductId(int productId)
        {
            if (productId <= 0)
            {
                return BadRequest("Invalid product Id");
            }

            try
            {
                var orders = await _orderService.GetOrderByProductIdAsync(productId);

                if (orders == null || !orders.Any())
                {
                    return NotFound($"No orders found for product with Id {productId}");
                }

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderReadDto>> CreateOrder(OrderCreateDto orderCreateDto)
        {
            try
            {
                int.TryParse(User.FindFirstValue("id"), out int customerId);
                var order = await _orderService.CreateOrderAsync(orderCreateDto, customerId);
                await _emailService.SendEmailAsync(new()
                {
                    To = orderCreateDto.Email,
                    Subject = "Order confirmation",
                    Body = $"<h1>Your order has beed confirmed</h1><h4>Order number: {order.Id}</h4>"
                });
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, OrderUpdateDto orderUpdateDto)
        {
            if (id <= 0 || !ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }

            try
            {
                await _orderService.UpdateOrderAsync(id, orderUpdateDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid order Id");
            }

            try
            {
                await _orderService.DeleteOrderByIdAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
