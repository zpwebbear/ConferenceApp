using System;
using System.Linq;
using System.Threading.Tasks;
using ConferenceApp.Helpers;
using ConferenceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConferenceApp.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly ConferenceAppContext _context;
        private readonly DbSet<Participant> entity;
        private readonly ILogger _logger;
        public ParticipantService(ConferenceAppContext context, ILogger<ParticipantService> logger)
        {
            _logger = logger;
            _context = context;
            entity = _context.Set<Participant>();
        }
        public PaginatedList<Participant> PaginatedList(int currentPage)
        {
            var participants = PaginatedList<Participant>.ToPaginatedList(
                entity.AsNoTracking().OrderBy(p => p.FirstName),
                currentPage,
                10);

            _logger.LogInformation("Participants total {total}, current page {}", participants.TotalPages, participants.CurrentPage);
            return participants;
        }

        public async Task<Participant> Get(int ID)
        {
            return await entity.SingleAsync(p => p.ID == ID);
        }

        public void Update(Participant participant)
        {
            var existedParticipant = _context.Participants.Find(participant.ID);
            var newCountry = _context.Countries.Find(participant.Country.ID);
            existedParticipant.Country = newCountry;
            _context.SaveChanges();
        }
    }
}