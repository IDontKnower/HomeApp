using System;
using System.Threading.Tasks;
using AutoMapper;
using Dawn;
using HomeApp.WebApi.Contracts;
using HomeApp.WebApi.Model.OpenWeatherApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HomeApp.WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController: ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public WeatherForecastController(IWeatherService weatherService, ILogger logger,
            IMapper mapper)
        {
            Guard.Argument(weatherService, nameof(weatherService)).NotNull();
            Guard.Argument(logger, nameof(logger)).NotNull();
            Guard.Argument(mapper, nameof(mapper)).NotNull();

            _weatherService = weatherService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherForecast(float latitude, float longitude)
        {
            try
            {
                var weatherForecast = await _weatherService.GetWeatherForecast(latitude, longitude);
                var mappedResult = _mapper.Map<OpenWeatherResponse>(weatherForecast);
                return Ok(mappedResult);
            }
            catch (Exception e)
            {
                _logger.Error(e, "Error while getting weather forecast");
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}