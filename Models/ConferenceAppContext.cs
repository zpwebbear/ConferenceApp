using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Participant>()
                .Property(p => p.Inserted)
                .HasDefaultValueSql("CONVERT(datetime2, GETDATE())");

            modelBuilder.Entity<Participant>()
                .Property(p => p.LastUpdated)
                .ValueGeneratedOnAddOrUpdate();


            modelBuilder.Entity<Participant>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Participant>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }

        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }
    }
}