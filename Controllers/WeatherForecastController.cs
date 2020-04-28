using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : Controller
    {
        WeatherForecastService _weatherForecastService;

        public WeatherForecastController(WeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
        {
            return await _weatherForecastService.GetForecastAsync(DateTime.Now);
        }
    }
}