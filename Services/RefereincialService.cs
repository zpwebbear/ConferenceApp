using System.Collections.Generic;
using System.Threading.Tasks;
using ConferenceApp.Models;
using Microsoft.EntityFrameworkCore;


namespace ConferenceApp.Services
{
    // Maybe this class is redundant but I wanted to try some C# abilities
    public class RefereincialService<T> : IReferencialService<T> where T : BaseReferenceModel
    {
        protected readonly ConferenceAppContext _context;
        private DbSet<T> entity;
        public RefereincialService(ConferenceAppContext context)
        {
            _context = context;
            entity = _context.Set<T>();
        }

        public async Task<List<T>> Get()
        {
            return await entity.ToListAsync();
        }

        public async Task<T> Get(int Id)
        {
            return await entity.SingleAsync((T c) => c.ID == Id );
        }
    }
}