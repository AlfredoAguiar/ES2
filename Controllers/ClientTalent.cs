using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienttalentsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ClienttalentsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Clienttalents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetClienttalents()
        {
            var clienttalents = await _context.Clienttalents
                .Select(ct => new
                {
                    ct.ClientTalentId,
                    ct.ClientId,
                    ct.TalentId,
                    ct.Client,
                    ct.Talent
                })
                .ToListAsync();

            if (!clienttalents.Any())
            {
                return NotFound();
            }

            return clienttalents;
        }

        // GET: api/Clienttalents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clienttalent>> GetClienttalent(Guid id)
        {
            var clienttalent = await _context.Clienttalents.FindAsync(id);

            if (clienttalent == null)
            {
                return NotFound();
            }

            return clienttalent;
        }

        // PUT: api/Clienttalents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienttalent(Guid id, Clienttalent clienttalent)
        {
            if (id != clienttalent.ClientTalentId)
            {
                return BadRequest();
            }

            _context.Entry(clienttalent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienttalentExists(id))
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

        // POST: api/Clienttalents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clienttalent>> PostClienttalent(Clienttalent clienttalent)
        {
            _context.Clienttalents.Add(clienttalent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClienttalent", new { id = clienttalent.ClientTalentId }, clienttalent);
        }

        // DELETE: api/Clienttalents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienttalent(Guid id)
        {
            var clienttalent = await _context.Clienttalents.FindAsync(id);
            if (clienttalent == null)
            {
                return NotFound();
            }

            _context.Clienttalents.Remove(clienttalent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienttalentExists(Guid id)
        {
            return _context.Clienttalents.Any(ct => ct.ClientTalentId == id);
        }
    }
}