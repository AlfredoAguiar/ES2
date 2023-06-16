using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;

using WebApplication2.modls;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AuthController(MyDbContext context)
        {
            _context = context;
        }
        
        [HttpPost("login")]
        public IActionResult Login([FromBody] login login)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);

            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            // User authentication successful, return a success response
            return Ok();
        }
    }
}