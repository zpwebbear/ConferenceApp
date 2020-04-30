using System.Threading.Tasks;
using ConferenceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConferenceApp.Services
{
    public class GenderService : RefereincialService<Gender>, IGenderService
    {
        public GenderService(ConferenceAppContext context) : base(context) { }
        public async Task<Gender> Get(string gender)
        {
            return await _context.Set<Gender>().SingleAsync((Gender c) => c.Value == gender );
        }
    }
}