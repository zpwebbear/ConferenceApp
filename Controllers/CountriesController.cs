using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConferenceApp.Models;
using ConferenceApp.Services;

namespace ConferenceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ConferenceAppContext _context;
        private readonly CountryService _service;


        public CountriesController(
            ConferenceAppContext context,
            CountryService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        // GET: api/Countries/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // GET: api/Countries/UA
        [HttpGet("{iso}")]
        public async Task<ActionResult<Country>> GetCountry(string Iso)
        {
            // I tried to use both - scafolled approach with context and service approach
            // I think service approach is more correct;
            var country = await _service.Get(Iso);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.ID == id);
        }
    }
}
