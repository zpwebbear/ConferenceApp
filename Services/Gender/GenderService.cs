using System.Threading.Tasks;
using ConferenceApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ConferenceApp.Services
{
    public class GenderService : RefereincialService<Gender>, IGenderService
    {
        private ILogger _logger;
        public GenderService(
            ConferenceAppContext context,
            ILogger<GenderService> logger
            ) : base(context)
        {
            _logger = logger;
        }
        public async Task<Gender> Get(string gender)
        {
             _logger.LogInformation("Gender value passed: {gender}", gender);
            return await _context.Set<Gender>().SingleAsync((Gender c) => c.Value == gender);
        }
    }
}