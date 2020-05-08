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

            return participants;
        }

        public async Task<Participant> Get(int ID)
        {
            return await entity.Include(p => p.Country).Include(p => p.Role).Include(p => p.Gender).SingleAsync(p => p.ID == ID);
        }

        public void UpdateFromRazor(Participant participant, Country country, ParticipantRole role, Gender gender)
        {
            Participant existedParticipant = _context.Participants.Find(participant.ID);
            existedParticipant.Country = _context.Countries.Find(country.ID);
            existedParticipant.Gender = _context.Genders.Find(gender.ID);
            existedParticipant.Role = _context.ParticipantRoles.Find(role.ID);

            _context.SaveChanges();
        }

        public void Delete(Participant participant)
        {
            _context.Remove(participant);
        }
    }
}