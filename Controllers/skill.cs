using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public SkillsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetSkills()
        {
            var skills = await _context.Skills
                .Select(s => new
                {
                    s.SkillId,
                    s.Name,
                    s.ProfessionArea,
                    Userskills = s.Userskills.Select(us => new
                    {
                        us.UserSkillId,
                        us.UserId,
                        us.SkillId,
                        us.YearsOfExperience,
                        us.Skill,
                        us.User
                    })
                })
                .ToListAsync();

            if (!skills.Any())
            {
                return NotFound();
            }

            return skills;
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkill(Guid id)
        {
            var skill = await _context.Skills.FindAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            return skill;
        }

        // PUT: api/Skills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill(Guid id, Skill skill)
        {
            if (id != skill.SkillId)
            {
                return BadRequest();
            }

            _context.Entry(skill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(id))
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

        // POST: api/Skills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Skill>> PostSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSkill", new { id = skill.SkillId }, skill);
        }

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(Guid id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkillExists(Guid id)
        {
            return _context.Skills.Any(s => s.SkillId == id);
        }
    }
}