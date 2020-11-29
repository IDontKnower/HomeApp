using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dawn;
using HomeApp.WebApi.Contracts;
using HomeApp.WebApi.DTO.OpenWeatherApi;
using HomeApp.WebApi.Settings;
using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Serializers.SystemTextJson;

namespace HomeApp.WebApi.Services
{
    public class OpenWeatherService: IWeatherService
    {
        private readonly ILogger _logger;
        private readonly RestClient _weatherClient;
        private readonly Dictionary<string, string> _defaultParameters;

        public OpenWeatherService(WeatherSettings weatherSettings, ILogger<OpenWeatherService> logger)
        {
            Guard.Argument(weatherSettings, nameof(weatherSettings)).NotNull();
            Guard.Argument(logger, nameof(logger)).NotNull();

            _logger = logger;
            _weatherClient = new RestClient(weatherSettings.ApiUrl);
            _weatherClient.UseSystemTextJson();
            _defaultParameters = new Dictionary<string, string>()
                {
                    {"appid", weatherSettings.ApiKey},
                    {"exclude", weatherSettings.Exclude},
                    {"units", weatherSettings.Units},
                    {"lang", weatherSettings.Language}
                };
        }

        public async Task<OpenWeatherResponse> GetWeatherForecast(float latitude, float longitude)
        {
            try
            {
                var request = new RestRequest();
                AddDefaultParametersToRequest(request);
                request.AddParameter("lat", latitude);
                request.AddParameter("lon", longitude);
                try
                {
                    var response = await _weatherClient.GetAsync<OpenWeatherResponse>(request);
                    return response;
                }
                catch (Exception e)
                {
                        Console.WriteLine(e);
                        throw;
                }
                //try
                //{
                //    var config = JsonConvert.DeserializeObject<OpenWeatherResponse>(response.Content);
                //    return config;
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e);
                //    throw;
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void AddDefaultParametersToRequest(RestRequest request)
        {
            foreach (var (property, value) in _defaultParameters)
            {
                request.AddParameter(property, value, ParameterType.QueryString);
            }
        }
    }
}