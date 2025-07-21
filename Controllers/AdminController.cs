using e_commerce_api.Context;
using e_commerce_api.Services;
using Microsoft.AspNetCore.Mvc;
using e_commerce_api.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
     public readonly EcommerceContext _context;
     private ReturnCd rtn = new ReturnCd();

        public AdminController(EcommerceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Admin admin)
        {
            try
            {
                if (admin == null)
                {
                    rtn.Message = "Invalid input data.";
                    rtn.StatusCode = 0;
                    return Ok(rtn);
                }
               else
               {
                    _context.Admins.Add(admin);
                    await _context.SaveChangesAsync();
                    rtn.data = admin;
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
                var admins = await _context.Admins.ToListAsync();
                if (admins == null || !admins.Any())
                {
                    rtn.Message = "No data found.";
                    rtn.StatusCode = 0;
                    return Ok(rtn);
                }
                rtn.data = admins;
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
                var admin = await _context.Admins.FindAsync(id);
                if (admin == null)
                {
                    rtn.Message = "Admin not found.";
                    rtn.StatusCode = 0;
                    return Ok(rtn);
                }
                rtn.data = admin;
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
        public async Task<IActionResult> Update(int id, [FromBody] Admin admin)
        {
            try
            {
                if (admin == null || id != admin.Id)
                {
                    rtn.Message = "Invalid input data.";
                    rtn.StatusCode = 0;
                    return Ok(rtn);
                }
                var existingAdmin = await _context.Admins.FindAsync(id);
                if (existingAdmin == null)
                {
                    rtn.Message = "Admin not found.";
                    rtn.StatusCode = 0;
                    return Ok(rtn);
                }
                _context.Entry(existingAdmin).CurrentValues.SetValues(admin);
                await _context.SaveChangesAsync();
                rtn.data = existingAdmin;
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
                var admin = await _context.Admins.FindAsync(id);
                if (admin == null)
                {
                    rtn.Message = "Admin not found.";
                    rtn.StatusCode = 0;
                    return Ok(rtn);
                }
                _context.Admins.Remove(admin);
                await _context.SaveChangesAsync();
                rtn.data = admin;
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
