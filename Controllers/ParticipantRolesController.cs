using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConferenceApp.Models;
using ConferenceApp.Services;

namespace ConferenceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantRolesController : ControllerBase
    {
        private readonly IParticipantRoleService _service;

        public ParticipantRolesController(IParticipantRoleService service)
        {
            _service = service;
        }

        // GET: api/ParticipantRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParticipantRole>>> GetParticipantRoles()
        {
            return await _service.Get();
        }

        // GET: api/ParticipantRoles/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ParticipantRole>> GetParticipantRole(int id)
        {
            var participantRole = await _service.Get(id);

            if (participantRole == null)
            {
                return NotFound();
            }

            return participantRole;
        }

        // GET: api/ParticipantRoles/Listener
        [HttpGet("{role}")]
        public async Task<ActionResult<ParticipantRole>> GetParticipantRole(string role)
        {
            var participantRole = await _service.Get(role);

            if (participantRole == null)
            {
                return NotFound();
            }

            return participantRole;
        }
    }
}
