using System.Threading.Tasks;
using ConferenceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenceApp.Services
{
    public class CountryService : RefereincialService<Country>, ICountryService
    {
        public CountryService(ConferenceAppContext context) : base(context) { }
        public async Task<Country> Get(string Iso)
        {
            return await _context.Set<Country>().SingleAsync((Country c) => c.Iso == Iso );
        }
    }
}