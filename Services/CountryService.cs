using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConferenceApp.Services
{
    public class CountryService
    {
        private readonly ConferenceAppContext _context;

        public CountryService(ConferenceAppContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> Get()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> Get(int Id)
        {
            return await _context.Countries.SingleAsync((Country c) => c.ID == Id );
        }

        public async Task<Country> Get(string Iso)
        {
            return await _context.Countries.SingleAsync((Country c) => c.Iso == Iso );
        }
    }
}