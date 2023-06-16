
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Entities;
using WebApplication2.modls;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _context;

        public UsersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetUsers()
        {
            var users = await _context.Users
                .Select(b => new
                {
                    b.UserId,
                    b.Email,
                    b.Password,
                    b.Username,
                 
                })
                .ToListAsync();

            if (!users.Any())
            {
                return NotFound();
            }

            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsers(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(Guid id, User users)
        {
            if (id != users.UserId)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUsers(User users)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'MyDbContext.Users' is null.");
            }

            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.UserId }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
        
        // POST: api/Users/Login
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] login loginRequest)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginRequest.Username && u.Password == loginRequest.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            // Create claims for the authenticated user
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            // Sign in the user using cookies
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return Ok();
        }

    }
}