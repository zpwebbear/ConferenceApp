using System.Threading.Tasks;
using ConferenceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenceApp.Services
{
    public class ParticipantRoleService : RefereincialService<ParticipantRole>, IParticipantRoleService
    {
        public ParticipantRoleService(ConferenceAppContext context) : base(context) { }

        public async Task<ParticipantRole> Get(string role)
        {
            return await _context.Set<ParticipantRole>().SingleAsync((ParticipantRole c) => c.RoleName == role);
        }
    }
}