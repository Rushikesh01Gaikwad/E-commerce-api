using e_commerce_api.Context;
using e_commerce_api.Services;
using Microsoft.AspNetCore.Mvc;
using e_commerce_api.Models;

namespace e_commerce_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
     public readonly EcommerceContext _context;

        public AdminController(EcommerceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Admin admin)
        {
            var rtn = new ReturnCd();
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

    }
}
