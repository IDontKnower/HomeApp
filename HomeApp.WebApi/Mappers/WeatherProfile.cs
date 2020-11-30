using AutoMapper;
using DTOs = HomeApp.WebApi.DTO.OpenWeatherApi;
using Models = HomeApp.WebApi.Model.OpenWeatherApi;

namespace HomeApp.WebApi.Mappers
{
    public class WeatherProfile: Profile
    {
        public WeatherProfile()
        {
            CreateMap<DTOs.Current.CurrentWeather, Models.Current.CurrentWeather>();
            CreateMap<DTOs.Daily.DailyTemperature, Models.Daily.DailyTemperature>();
            CreateMap<DTOs.Daily.DailyWeather, Models.Daily.DailyWeather>();
            CreateMap<DTOs.Hourly.HourlyWeather, Models.Hourly.HourlyWeather>();
            CreateMap<DTOs.Weather, Models.Weather>();
            CreateMap<DTOs.WeatherDescription, Models.WeatherDescription>();
            CreateMap<DTOs.OpenWeatherResponse, Models.OpenWeatherResponse>();
        }
    }
}