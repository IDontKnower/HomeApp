using AutoMapper;
using HomeApp.WebApi.Mappers.Resolvers;
using DTOs = HomeApp.WebApi.DTO.OpenWeatherApi;
using Models = HomeApp.WebApi.Model.OpenWeatherApi;

namespace HomeApp.WebApi.Mappers
{
    public class WeatherProfile: Profile
    {
        public WeatherProfile()
        {
            CreateMap<DTOs.Current.CurrentWeather, Models.Current.CurrentWeather>()
                .ForMember(dest => dest.Pressure,
                    source => source.MapFrom<PressureResolver>());             CreateMap<DTOs.Daily.DailyTemperature, Models.Daily.DailyTemperature>();
            CreateMap<DTOs.Daily.DailyWeather, Models.Daily.DailyWeather>()
                .ForMember(dest => dest.Pressure,
                    source => source.MapFrom<DailyPressureResolver>());
            CreateMap<DTOs.Hourly.HourlyWeather, Models.Hourly.HourlyWeather>()
                .ForMember(dest => dest.Pressure,
                    source => source.MapFrom<PressureResolver>());
            CreateMap<DTOs.Weather, Models.Weather>()
                .ForMember(dest => dest.Pressure, 
                    source => source.MapFrom<PressureResolver>());
            CreateMap<DTOs.WeatherDescription, Models.WeatherDescription>();
            CreateMap<DTOs.OpenWeatherResponse, Models.OpenWeatherResponse>();
        }
    }
}