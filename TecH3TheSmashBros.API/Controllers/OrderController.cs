using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TecH3TheSmashBros.API.Models;
using TecH3TheSmashBros.API.Services;


namespace TecH3TheSmashBros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var order = await _orderService.GetAllOrder();
                if (order == null)
                {
                    return Problem("Din idiot");
                }
                if (order.Count == 0)
                {
                    return NoContent();
                }
                return Ok(order);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var order = await _orderService.GetOrderById(id);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order, List<OrderDetail> orderDetails)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest("Author Fail.....");
                }
                var neworder = await _orderService.Create(order, orderDetails);

                return Ok(neworder);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Order order, List<OrderDetail> orderDetails)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("CANNOT UPDATE");
                }
                var updateorder = await _orderService.Update(id, order,orderDetails);
                if (updateorder == null)
                {
                    return NotFound("Could not found id");
                }
                return Ok(updateorder);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("CANNOT DELETE");
                }
                var Deleteorder = await _orderService.Delete(id);
                return Ok(Deleteorder);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}