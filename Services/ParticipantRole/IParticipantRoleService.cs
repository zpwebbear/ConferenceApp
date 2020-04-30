using System.Threading.Tasks;
using ConferenceApp.Models;

namespace ConferenceApp.Services
{
    public interface IParticipantRoleService : IReferencialService<ParticipantRole>
    {
        Task<ParticipantRole> Get(string role);
    }
}