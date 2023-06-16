using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperiencesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ExperiencesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Experiences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetExperiences()
        {
            var experiences = await _context.Experiences
                .Select(b => new
                {
                    b.ExperienceId,
                    b.Title,
                    b.TalentId,
                    b.CompanyName,
                    b.EndYear,
                    b.StartYear
                })
                .ToListAsync();

            if (!experiences.Any())
            {
                return NotFound();
            }

            return experiences;
        }

        // GET: api/Experiences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Experience>> GetExperience(Guid id)
        {
            var experience = await _context.Experiences.FindAsync(id);

            if (experience == null)
            {
                return NotFound();
            }

            return experience;
        }

        // PUT: api/Experiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperience(Guid id, Experience experience)
        {
            if (id != experience.ExperienceId)
            {
                return BadRequest();
            }

            _context.Entry(experience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienceExists(id))
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

        // POST: api/Experiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Experience>> PostExperience(Experience experience)
        {
            _context.Experiences.Add(experience);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExperience", new { id = experience.ExperienceId }, experience);
        }

        // DELETE: api/Experiences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperience(Guid id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            if (experience == null)
            {
                return NotFound();
            }

            _context.Experiences.Remove(experience);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExperienceExists(Guid id)
        {
            return _context.Experiences.Any(e => e.ExperienceId == id);
        }
    }
}