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
    public class GendersController : ControllerBase
    {
        private readonly IGenderService _service;

        public GendersController(IGenderService service)
        {
            _service = service;
        }

        // GET: api/Genders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gender>>> GetGenders()
        {
            return await _service.Get();
        }

        // GET: api/Genders/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Gender>> GetGender(int id)
        {
            var gender = await _service.Get(id);

            if (gender == null)
            {
                return NotFound();
            }

            return gender;
        }

        // GET: api/Genders/Male
        [HttpGet("{genderValue}")]
        public async Task<ActionResult<Gender>> GetGender(string genderValue)
        {
            var gender = await _service.Get(genderValue);

            if (gender == null)
            {
                return NotFound();
            }

            return gender;
        }

    }
}
