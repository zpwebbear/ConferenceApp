using ConferenceApp.Helpers;
using ConferenceApp.Models;

namespace ConferenceApp.Services
{
    public interface IParticipantService
    {
        public PaginatedList<Participant> PaginatedList(int currentPage);
    }
}