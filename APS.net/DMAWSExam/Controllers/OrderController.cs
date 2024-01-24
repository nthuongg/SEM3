using DMAWSExam.DTOs;
using DMAWSExam.Entities;
using DMAWSExam.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMAWSExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;
        public OrderController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("get-all-orders")]
        public async Task<ActionResult> GetAllOrder()
        {
            try
            {
                List<Order> orders = await _context.Orders.OrderByDescending(s => s.OrderId).ToListAsync();
                List<OrderDTO> orderDTOs = new List<OrderDTO>();
                foreach (var order in orders)
                {
                    orderDTOs.Add(new OrderDTO
                    {
                        OrderId = order.OrderId,
                        ItemCode = order.ItemCode,
                        ItemName = order.ItemName,
                        ItemQty = order.ItemQty,
                        OrderDelivery = order.OrderDelivery,
                        OrderAddress = order.OrderAddress,
                        PhoneNumber = order.PhoneNumber,
                    });
                }
                return Ok(orderDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("create-order")]
        public async Task<ActionResult> CreateOrder(CreateOrder model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Order order = new Order
                    {
                        ItemCode = model.ItemCode,
                        ItemName = model.ItemName,
                        ItemQty = model.ItemQty,
                        OrderDelivery = model.OrderDelivery,
                        OrderAddress = model.OrderAddress,
                        PhoneNumber = model.PhoneNumber,
                    };

                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();

                    return Created($"get-by-id?id={order.OrderId}", new OrderDTO
                    {
                        OrderId = order.OrderId,
                        ItemCode = order.ItemCode,
                        ItemName = order.ItemName,
                        ItemQty = order.ItemQty,
                        OrderDelivery = order.OrderDelivery,
                        OrderAddress = order.OrderAddress,
                        PhoneNumber = order.PhoneNumber,
                    });
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            var msgs = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage);
            return BadRequest(string.Join(" | ", msgs));
        }

        [HttpPut("edit-order")]
        public async Task<IActionResult> UpdateOrder(EditOrder model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Order orderExist = await _context.Orders.AsNoTracking().FirstOrDefaultAsync(e => e.OrderId == model.Id);

                    if (orderExist != null)
                    {
                        Order order = new Order
                        {
                            OrderId = model.Id,
                            ItemCode = orderExist.ItemCode,
                            ItemName = orderExist.ItemName,
                            ItemQty = orderExist.ItemQty,
                            OrderDelivery = model.OrderDelivery,
                            OrderAddress = model.OrderAddress,
                            PhoneNumber = orderExist.PhoneNumber,
                        };

                        if (order != null)
                        {
                            _context.Orders.Update(order);
                            await _context.SaveChangesAsync();
                            return NoContent();
                        }

                        return NotFound();
                    }
                    else
                    {
                        return NotFound();
                    }



                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

            }
            return BadRequest();
        }
    }
}
