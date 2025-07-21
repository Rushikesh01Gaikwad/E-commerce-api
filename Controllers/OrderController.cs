using e_commerce_api.Context;
using e_commerce_api.Services;
using Microsoft.AspNetCore.Mvc;
using e_commerce_api.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_api.Controllers
{
    public class OrderController : ControllerBase
    {
        private ReturnCd rtn = new ReturnCd();
        private readonly EcommerceContext _context;
        public OrderController(EcommerceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Orders order)
        {
            try
            {
                if (order == null)
                {
                    rtn.Message = "Invalid input data.";
                    rtn.StatusCode = 0;
                    return Ok(rtn);
                }
                else
                {
                    _context.Orders.Add(order);
                    await _context.SaveChangesAsync();
                    rtn.data = order;
                    return Ok(rtn);
                }
            }
            catch (Exception ex)
            {
                rtn.Message = ex.Message;
                rtn.StatusCode = 0;
                return Ok(rtn);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var orders = await _context.Orders.ToListAsync();
                if (orders == null || !orders.Any())
                {
                    rtn.Message = "No data found.";
                    rtn.StatusCode = 0;
                    return Ok(rtn);
                }
                rtn.data = orders;
                return Ok(rtn);
            }
            catch (Exception ex)
            {
                rtn.Message = ex.Message;
                rtn.StatusCode = 0;
                return Ok(rtn);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                if (order == null)
                {
                    rtn.Message = "Order not found.";
                    rtn.StatusCode = 0;
                    return Ok(rtn);
                }
                rtn.data = order;
                return Ok(rtn);
            }
            catch (Exception ex)
            {
                rtn.Message = ex.Message;
                rtn.StatusCode = 0;
                return Ok(rtn);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Orders order)
        {
            try
            {
                if (order == null)
                {
                    rtn.Message = "Invalid input data.";
                    rtn.StatusCode = 0;
                    return Ok(rtn);
                }
                var existingOrder = await _context.Orders.FindAsync(id);
                if (existingOrder == null)
                {
                    rtn.Message = "Order not found.";
                    rtn.StatusCode = 0;
                    return Ok(rtn);
                }

                _context.Entry(order).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                rtn.data = existingOrder;
                return Ok(rtn);
            }
            catch (Exception ex)
            {
                rtn.Message = ex.Message;
                rtn.StatusCode = 0;
                return Ok(rtn);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                if (order == null)
                {
                    rtn.Message = "Order not found.";
                    rtn.StatusCode = 0;
                    return Ok(rtn);
                }
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                rtn.data = order;
                return Ok(rtn);
            }
            catch (Exception ex)
            {
                rtn.Message = ex.Message;
                rtn.StatusCode = 0;
                return Ok(rtn);
            }
        }
    }
}
