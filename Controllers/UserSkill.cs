using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserskillsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public UserskillsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Userskills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetUserskills()
        {
            var userskills = await _context.Userskills
                .Select(us => new
                {
                    us.UserSkillId,
                    us.UserId,
                    us.SkillId,
                    us.YearsOfExperience, 
                    us.Skill,
                    us.User
                })
                .ToListAsync();

            if (!userskills.Any())
            {
                return NotFound();
            }

            return userskills;
        }

        // GET: api/Userskills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Userskill>> GetUserskill(Guid id)
        {
            var userskill = await _context.Userskills.FindAsync(id);

            if (userskill == null)
            {
                return NotFound();
            }

            return userskill;
        }

        // PUT: api/Userskills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserskill(Guid id, Userskill userskill)
        {
            if (id != userskill.UserSkillId)
            {
                return BadRequest();
            }

            _context.Entry(userskill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserskillExists(id))
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

        // POST: api/Userskills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Userskill>> PostUserskill(Userskill userskill)
        {
            _context.Userskills.Add(userskill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserskill", new { id = userskill.UserSkillId }, userskill);
        }

        // DELETE: api/Userskills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserskill(Guid id)
        {
            var userskill = await _context.Userskills.FindAsync(id);
            if (userskill == null)
            {
                return NotFound();
            }

            _context.Userskills.Remove(userskill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserskillExists(Guid id)
        {
            return _context.Userskills.Any(us => us.UserSkillId == id);
        }
    }
}