using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Context;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ClientsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetClients()
        {
            var clients = await _context.Clients
                .Select(c => new
                {
                    c.ClientId,
                    c.Name,
                    Clienttalents = c.Clienttalents.Select(ct => new
                    {
                        ct.ClientTalentId,
                        ct.ClientId,
                        ct.TalentId,
                        ct.Client,
                        ct.Talent
                    }),
                    Workproposals = c.Workproposals.Select(wp => new
                    {
                        wp.ProposalId,
                        wp.UserId,
                        wp.ClientId,
                        wp.Name,
                        wp.TalentCategory,
                        wp.SkillsRequired,
                        wp.MinYearsOfExperience,
                        wp.TotalHours,
                        wp.Description,
                        wp.Client,
                        wp.User
                    })
                })
                .ToListAsync();

            if (!clients.Any())
            {
                return NotFound();
            }

            return clients;
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(Guid id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(Guid id, Client client)
        {
            if (id != client.ClientId)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(Guid id)
        {
            return _context.Clients.Any(c => c.ClientId == id);
        }
    }
}