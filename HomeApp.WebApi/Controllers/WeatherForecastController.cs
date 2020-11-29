using System;
using System.Threading.Tasks;
using Dawn;
using HomeApp.WebApi.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HomeApp.WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController: ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger _logger;

        public WeatherForecastController(IWeatherService weatherService, ILogger<WeatherForecastController> logger)
        {
            Guard.Argument(weatherService, nameof(weatherService)).NotNull();
            Guard.Argument(logger, nameof(logger)).NotNull();

            _weatherService = weatherService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherForecast(float latitude, float longitude)
        {
            try
            {
                var weatherForecast = await _weatherService.GetWeatherForecast(latitude, longitude);
                return Ok(weatherForecast);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error while getting weather forecast");
                return Forbid();
            }
        }
    }
}