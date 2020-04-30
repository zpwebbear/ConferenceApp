using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConferenceApp.Models;

namespace ConferenceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantRolesController : ControllerBase
    {
        private readonly ConferenceAppContext _context;

        public ParticipantRolesController(ConferenceAppContext context)
        {
            _context = context;
        }

        // GET: api/ParticipantRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipantRole>>> GetParticipantRoles()
        {
            return await _context.ParticipantRoles.ToListAsync();
        }

        // GET: api/ParticipantRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParticipantRole>> GetParticipantRole(int id)
        {
            var participantRole = await _context.ParticipantRoles.FindAsync(id);

            if (participantRole == null)
            {
                return NotFound();
            }

            return participantRole;
        }

        // PUT: api/ParticipantRoles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipantRole(int id, ParticipantRole participantRole)
        {
            if (id != participantRole.ID)
            {
                return BadRequest();
            }

            _context.Entry(participantRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantRoleExists(id))
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

        // POST: api/ParticipantRoles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ParticipantRole>> PostParticipantRole(ParticipantRole participantRole)
        {
            _context.ParticipantRoles.Add(participantRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipantRole", new { id = participantRole.ID }, participantRole);
        }

        // DELETE: api/ParticipantRoles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ParticipantRole>> DeleteParticipantRole(int id)
        {
            var participantRole = await _context.ParticipantRoles.FindAsync(id);
            if (participantRole == null)
            {
                return NotFound();
            }

            _context.ParticipantRoles.Remove(participantRole);
            await _context.SaveChangesAsync();

            return participantRole;
        }

        private bool ParticipantRoleExists(int id)
        {
            return _context.ParticipantRoles.Any(e => e.ID == id);
        }
    }
}
