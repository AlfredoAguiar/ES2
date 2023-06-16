using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Context;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalentsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TalentsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Talents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetTalents()
        {
            var talents = await _context.Talents
                .Select(t => new
                {
                    t.TalentId,
                    t.Name,
                    t.Country,
                    t.Email,
                    t.HourlyRate,
                    t.IsPublic,
                    Clienttalents = t.Clienttalents.Select(ct => new
                    {
                        ct.ClientTalentId,
                        ct.ClientId,
                        ct.TalentId,
                        Client = ct.Client,
                        Talent = ct.Talent
                    }),
                    Experiences = t.Experiences.Select(e => new
                    {
                        e.ExperienceId,
                        e.TalentId,
                        e.Title,
                        e.CompanyName,
                        e.StartYear,
                        e.EndYear,
                        Talent = e.Talent
                    })
                })
                .ToListAsync();

            if (!talents.Any())
            {
                return NotFound();
            }

            return talents;
        }

        // GET: api/Talents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Talent>> GetTalent(Guid id)
        {
            var talent = await _context.Talents.FindAsync(id);

            if (talent == null)
            {
                return NotFound();
            }

            return talent;
        }

        // PUT: api/Talents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTalent(Guid id, Talent talent)
        {
            if (id != talent.TalentId)
            {
                return BadRequest();
            }

            _context.Entry(talent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TalentExists(id))
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

        // POST: api/Talents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Talent>> PostTalent(Talent talent)
        {
            _context.Talents.Add(talent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTalent", new { id = talent.TalentId }, talent);
        }

        // DELETE: api/Talents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTalent(Guid id)
        {
            var talent = await _context.Talents.FindAsync(id);
            if (talent == null)
            {
                return NotFound();
            }

            _context.Talents.Remove(talent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TalentExists(Guid id)
        {
            return _context.Talents.Any(t => t.TalentId == id);
        }
    }
}