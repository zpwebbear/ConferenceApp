using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConferenceApp.Models
{
    public class ConferenceAppContext : IdentityDbContext
    {
        public ConferenceAppContext(DbContextOptions<ConferenceAppContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<ParticipantRole> ParticipantRoles { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Participant> Participants { get; set; }

    }
}