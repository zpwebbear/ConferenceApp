using ConferenceApp.Helpers;
using ConferenceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConferenceApp.Services
{
    public interface IParticipantService
    {
        public PaginatedList<Participant> PaginatedList(int currentPage);
        public Task<Participant> Get(int ID);
    }
}