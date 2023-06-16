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
    public class WorkproposalsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public WorkproposalsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Workproposals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetWorkproposals()
        {
            var workproposals = await _context.Workproposals
                .Select(wp => new
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
                    Client = wp.Client,
                    User = wp.User
                })
                .ToListAsync();

            if (!workproposals.Any())
            {
                return NotFound();
            }

            return workproposals;
        }

        // GET: api/Workproposals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workproposal>> GetWorkproposal(Guid id)
        {
            var workproposal = await _context.Workproposals.FindAsync(id);

            if (workproposal == null)
            {
                return NotFound();
            }

            return workproposal;
        }

        // PUT: api/Workproposals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkproposal(Guid id, Workproposal workproposal)
        {
            if (id != workproposal.ProposalId)
            {
                return BadRequest();
            }

            _context.Entry(workproposal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkproposalExists(id))
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

        // POST: api/Workproposals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Workproposal>> PostWorkproposal(Workproposal workproposal)
        {
            _context.Workproposals.Add(workproposal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkproposal", new { id = workproposal.ProposalId }, workproposal);
        }

        // DELETE: api/Workproposals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkproposal(Guid id)
        {
            var workproposal = await _context.Workproposals.FindAsync(id);
            if (workproposal == null)
            {
                return NotFound();
            }

            _context.Workproposals.Remove(workproposal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkproposalExists(Guid id)
        {
            return _context.Workproposals.Any(wp => wp.ProposalId == id);
        }
    }
}