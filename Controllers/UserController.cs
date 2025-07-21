using e_commerce_api.Services;
using Microsoft.AspNetCore.Mvc;
using e_commerce_api.Models;
using e_commerce_api.Context;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_api.Controllers
{
    public class UserController : ControllerBase
    {
        private ReturnCd rtn = new ReturnCd();
        private readonly EcommerceContext _context;
        public UserController(EcommerceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    rtn.Message = "Invalid input data.";
                    rtn.StatusCode = 0;
                    return Ok(rtn);
                }
                else
                {
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                    rtn.data = user;
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
                var users = await _context.Users.ToListAsync();
                if (users == null)
                {
                    rtn.Message = "No data found.";
                    rtn.StatusCode = 0;
                    return Ok(rtn);
                }
                rtn.data = users;
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
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    rtn.Message = "User not found.";
                    rtn.StatusCode = 0;
                    return Ok(rtn);
                }
                else
                {
                    rtn.data = user;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id, [FromBody] User user)
        {
            try
            {
                if (user == null || id != user.Id)
                {
                    rtn.Message = "Invalid input data.";
                    rtn.StatusCode = 0;
                    return Ok(rtn);
                }
                else
                {
                    _context.Users.Update(user);
                    _context.SaveChanges();
                    rtn.data = user;
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    rtn.Message = "User not found.";
                    rtn.StatusCode = 0;
                    return Ok(rtn);
                }
                else
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    rtn.data = user;
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
    }
}
